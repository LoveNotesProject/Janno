using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Janno.Data.User {

  public interface IUserStore : IUserStore<User> {

    Task<UserSearch> GetUserSearchAsync(string userId, CancellationToken cancellationToken);

  }

}