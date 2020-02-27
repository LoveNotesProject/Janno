using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    
  }

}