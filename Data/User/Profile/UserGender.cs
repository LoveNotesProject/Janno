using System.ComponentModel.DataAnnotations;

namespace Janno.Data.User.Profile {

  public enum UserGender {

    [Display(Name = "Männlich")] MALE = 0,
    [Display(Name = "Weiblich")] FEMALE = 1

  }

}