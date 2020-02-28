using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Janno.Data.User.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Janno.Data.User {

  public class UserManager : UserManager<User> {

    protected internal IUserStore UserStore { get; set; }

    public UserManager(IUserStore store, IOptions<IdentityOptions> optionsAccessor,
      IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
      IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer,
      IdentityErrorDescriber errors,
      IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher,
      userValidators, passwordValidators, keyNormalizer, errors, services, logger) {
      this.UserStore = store;
    }

    #region UserSearch

    public async Task<UserSearch> GetUserSearchAsync(string userId) {
      this.ThrowIfDisposed();
      return await this.UserStore.GetUserSearchAsync(userId, this.CancellationToken);
    }

    #endregion

    #region UserInterest

    public async Task<UserInterest> GetUserInterestAsync(string userId) {
      this.ThrowIfDisposed();
      return await this.UserStore.GetUserInterestAsync(userId, this.CancellationToken);
    }


    #endregion


    #region UserSport


    public async Task<UserSport> GetUserSportAsync(string userId) {
      this.ThrowIfDisposed();
      return await this.UserStore.GetUserSportAsync(userId, this.CancellationToken);
    }

    #endregion
    
  }

}