using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Janno.Data.User.Profile {

  public class UserDetail {

    [ForeignKey("User")]
    public string UserDetailId { get; set; }

    [StringLength(16)]
    public string FirstName { get; set; }

    public UserGender Gender { get; set; }
    
    public int Age { get; set; }

    public DateTime LastLogin { get; set; }

    public bool IsOnline { get; set; }

    [JsonIgnore]
    public byte[] ProfileImage { get; set; }
    
    public virtual User User { get; set; }

  }

}