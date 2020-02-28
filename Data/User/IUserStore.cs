using System.Threading;
using System.Threading.Tasks;
using Janno.Data.User.Profile;
using Microsoft.AspNetCore.Identity;

namespace Janno.Data.User {

  public interface IUserStore : IUserStore<User> {

    Task<UserSearch> GetUserSearchAsync(string userId, CancellationToken cancellationToken);

    Task<UserInterest> GetUserInterestAsync(string userId, CancellationToken cancellationToken);

    Task<UserSport> GetUserSportAsync(string userId, CancellationToken cancellationToken);

  }

}