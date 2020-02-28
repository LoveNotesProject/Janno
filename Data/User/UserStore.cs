using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using EFSecondLevelCache.Core;
using Janno.Data.User.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Janno.Data.User {

  public class UserStore : IUserStore, IUserPasswordStore<User>, IUserRoleStore<User> {

    // https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/security/authentication/identity-custom-storage-providers/sample/CustomIdentityProviderSample/CustomProvider/CustomUserStore.cs
    // https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/security/authentication/identity-custom-storage-providers/sample/CustomIdentityProviderSample/CustomProvider/DapperUsersTable.cs
    // https://docs.microsoft.com/de-de/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-2.2
    // https://docs.microsoft.com/en-us/aspnet/identity/overview/extensibility/overview-of-custom-storage-providers-for-aspnet-identity

    private readonly UserContext Context;

    public UserStore(UserContext context) {
      this.Context = context;
    }

    public void Dispose() {
      Context.Dispose();
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      return Task.FromResult(user.UserName);
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (userName == null) throw new ArgumentNullException(nameof(userName));

      user.UserName = userName;

      return Task.FromResult<object>(null);
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      return Task.FromResult(user.NormalizedUserName);
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

      user.NormalizedUserName = normalizedName;
      return Task.FromResult<object>(null);
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      var existUser = this.ExistUser(user.Id, cancellationToken);

      if (existUser.Result) {
        return await Task.FromResult(IdentityResult.Failed(new IdentityError()));
      }

      await this.Context.AddAsync(user, cancellationToken);
      await this.Context.SaveChangesAsync(cancellationToken);

      return await Task.FromResult(IdentityResult.Success);
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      this.Context.Update(user);
      await this.Context.SaveChangesAsync(cancellationToken);

      return await Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      this.Context.User.Remove(user);

      return Task.FromResult(IdentityResult.Success);
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (userId == null) throw new ArgumentNullException(nameof(userId));

      return await LoadUserId(userId, cancellationToken);
    }

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      return await LoadUserUserName(normalizedUserName.ToLower(), cancellationToken);
    }

    // https://stackoverflow.com/questions/51004516/net-core-2-1-identity-get-all-users-with-their-associated-roles
    // https://www.c-sharpcorner.com/article/list-of-users-with-roles-in-mvc-asp-net-identity/
    private async Task<User> LoadUserId(string id, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      var user = await Context.Users
        .AsNoTracking()
        .Include(d => d.Detail)
        .Include(l => l.UserLocation)
        .Cacheable()
        .Where(t => t.Id == id)
        .FirstOrDefaultAsync(cancellationToken);

      stopwatch.Stop();
      Console.WriteLine("User: " + id + " loaded (" + stopwatch.ElapsedMilliseconds + "ms)");

      return user;
    }

    private async Task<User> LoadUserUserName(string userName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      var user = await Context.User
        .AsNoTracking()
        .Cacheable()
        .FirstOrDefaultAsync(t => t.UserName.Equals(userName), cancellationToken);
      return user;
    }

    private async Task<bool> ExistUser(string id, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();

      var user = await Context.User
        .AsNoTracking()
        .Cacheable()
        .Where(t => t.Id.Equals(id))
        .FirstOrDefaultAsync(cancellationToken);
      return user != null;
    }

    public async Task<List<User>> SearchUser(string key, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();

      if (!Regex.IsMatch(key, "^[a-zA-Z0-9_.-]*$")) return null;

      return await this.Context.User
        .AsNoTracking()
        .Cacheable()
        .Where(u => u.UserName.StartsWith(key))
        .ToListAsync(cancellationToken);
    }

    // IUserPasswordStore

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (passwordHash == null) throw new ArgumentNullException(nameof(passwordHash));
      user.PasswordHash = passwordHash;
      return Task.FromResult<object>(null);
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      return Task.FromResult(user.PasswordHash != null);
    }

    // region IUserRoleStore

    public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (roleName == null) throw new ArgumentNullException(nameof(roleName));
      throw new NotImplementedException();
    }

    public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (roleName == null) throw new ArgumentNullException(nameof(roleName));
      throw new NotImplementedException();
    }

    public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));

      var rolesQuery = from roles in Context.UserRoles
        join role in Context.Roles on roles.RoleId equals role.Id
        where roles.UserId == user.Id
        select new {
          role
        };

      return await rolesQuery
        .Select(t => t.role.Name)
        .AsNoTracking()
        .Cacheable()
        .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (roleName == null) throw new ArgumentNullException(nameof(roleName));

      var roleQuery = from roles in Context.UserRoles
        join role in Context.Roles on roles.RoleId equals role.Id
        where roles.UserId == user.Id
        select role;

      var userRoles = await roleQuery
        .AsNoTracking()
        .Cacheable()
        .ToListAsync(cancellationToken);

      foreach (var ur in userRoles) {
        if (ur.NormalizedName.Equals(roleName)) {
          return await Task.FromResult(true);
        }
      }

      return false;
    }

    public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (roleName == null) throw new ArgumentNullException(nameof(roleName));
      throw new NotImplementedException();
    }

    #region UserSearch

    /// <summary>
    /// Get from the database the specific user search request
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<UserSearch> GetUserSearchAsync(string userId, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (userId == null) throw new ArgumentNullException(nameof(userId));

      return await this.Context.Searches.Where(u => u.UserId == userId).FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

    #region UserInterest

    public async Task<UserInterest> GetUserInterestAsync(string userId, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (userId == null) throw new ArgumentNullException(nameof(userId));

      return await this.Context.Interests
        .Where(u => u.UserInterestId == userId)
        .Cacheable()
        .FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

    #region UserSport

    public async Task<UserSport> GetUserSportAsync(string userId, CancellationToken cancellationToken) {
      cancellationToken.ThrowIfCancellationRequested();
      if (userId == null) throw new ArgumentNullException(nameof(userId));

      return await this.Context.Sports
        .Where(u => u.UserSportId == userId)
        .Cacheable()
        .FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

  }

}