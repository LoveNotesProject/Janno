using System.ComponentModel.DataAnnotations.Schema;

namespace Janno.Data.User.Profile {

  /// <summary>
  /// Create UserSport table with all sport types
  /// Every field is a boolean with the default value 0
  /// </summary>
  public class UserSport {

    [ForeignKey("User")]
    public string UserSportId { get; set; }
    
    public bool Football { get; set; }
    
    public bool Soccerball { get; set; }
    
    public bool Volleyball { get; set; }
    
    public bool Basketball { get; set; }
    
    public bool Baseball { get; set; }
    
    public bool Tennis { get; set; }
    
    public bool Badminton { get; set; }
    
    public bool Swim { get; set; }
    
    public bool MiniGolf { get; set; }
    
    public bool Golf { get; set; }
    
    public bool Hike { get; set; }
    
    public bool Jog { get; set; }
    
    public bool Climb { get; set; }
    
    public bool Paddle { get; set; }
    
    public bool Gym { get; set; }
    
    public bool Hockey { get; set; }
    
    public bool Rugby { get; set; }
    
    public bool Bowling { get; set; }
    
    public bool Row { get; set; }
    
    public virtual User User { get; set; }
  }

}