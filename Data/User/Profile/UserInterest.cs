using System.ComponentModel.DataAnnotations.Schema;

namespace Janno.Data.User.Profile {

  public class UserInterest {

    [ForeignKey("User")]
    public string UserInterestId { get; set; }

    public bool Travel { get; set; }

    public bool Beach { get; set; }

    public bool Mountain { get; set; }

    public bool City { get; set; }

    public bool Party { get; set; }

    public bool Cinema { get; set; }

    public bool Movie { get; set; }

    public bool Theater { get; set; }

    public bool VideoGame { get; set; }

    public bool Nature { get; set; }

    public bool Grill { get; set; }

    public bool Music { get; set; }

    public bool School { get; set; }

    public bool Programming { get; set; }

    public bool Casino { get; set; }

    public bool Breakfast { get; set; }

    public bool Restaurant { get; set; }

    public bool Camera { get; set; }

    public bool Motorcycle { get; set; }

    public virtual User User { get; set; }
  }

}