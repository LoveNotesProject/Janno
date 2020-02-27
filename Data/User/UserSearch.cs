using System.ComponentModel.DataAnnotations.Schema;
using Janno.Data.User.Profile;

namespace Janno.Data.User {

  public class UserSearch {

    public string UserSearchId { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    
    public int MinimumAge { get; set; }
    
    public int MaximumAge { get; set; }

    public int Distance { get; set; }
    
    public int Amount { get; set; }
    
    public UserGender Gender { get; set; }
    
    public virtual User User { get; set; }
  }

}