using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace moment32.Models{

    // Class for renting information
    public class Renting{
        public int RentingId { get; set; }

        [Required(ErrorMessage = "Välj datum för uthyrning")]
        [DisplayName("Uthyrd")]
        public DateTime Rented { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Ange skivan")]
        [DisplayName("Skiva")]
        public int RecordId { get; set; }

        [Required(ErrorMessage = "Ange skivan")]
        [DisplayName("Skiva")]
        public Record? Record { get; set; }

        [Required(ErrorMessage = "Ange namn på användaren")]
        [DisplayName("Användare")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Ange namn på användaren")]
        [DisplayName("Användare")]
        public User? User { get; set; }
    }
}