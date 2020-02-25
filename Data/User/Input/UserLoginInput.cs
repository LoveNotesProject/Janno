using System.ComponentModel.DataAnnotations;

namespace Janno.Data.User.Input {

  public class UserLoginInput {

    [Required(ErrorMessage = "Kein Benutzername eingegeben.")]
    [MinLength(3, ErrorMessage = "Dein Benutzername muss mindestens 3 Buchstaben besitzen.")]
    [MaxLength(32, ErrorMessage = "Dein Benutzername darf nicht mehr als 32 Buchstaben besitzen.")]
    public string UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Kein Passwort eingegeben.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Dein Passwort muss mindestens 6 Buchstaben besitzen.")]
    [MaxLength(32, ErrorMessage = "Dein Passwort darf nicht mehr als 32 Buchstaben besitzen.")]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    
  }

}