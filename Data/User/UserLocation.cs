using System.ComponentModel.DataAnnotations.Schema;

namespace Janno.Data.User {

  public class UserLocation {

    [ForeignKey("User")]
    public string UserLocationId { get; set; }

    public string City { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public int Accuracy { get; set; }
    
    [NotMapped]
    public double Distance { get; set; }
    
    public virtual User User { get; set; }
  }

}