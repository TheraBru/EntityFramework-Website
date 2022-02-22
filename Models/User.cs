using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace moment32.Models{

     // Class for user
     public class User{

          [DisplayName("Användare")]
          public int UserId { get; set; }

          [Required(ErrorMessage = "Skriv in namnet på användaren")]
          [DisplayName("Användare")]
          public string? UserName { get; set; }
     }
}