using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Janno.Data.User {

  public class User : IdentityUser {

    public virtual ICollection<IdentityRole> UserRoles { get; set; }

  }

}