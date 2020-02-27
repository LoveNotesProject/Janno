using System.Collections.Generic;
using Janno.Data.User.Profile;
using Microsoft.AspNetCore.Identity;

namespace Janno.Data.User {

  public class User : IdentityUser {

    public virtual ICollection<IdentityRole> UserRoles { get; set; }
    public virtual ICollection<UserSearch> UserSearches { get; set; }
    
    public virtual UserLocation UserLocation { get; set; }

    public virtual UserDetail Detail { get; set; }
  }

}