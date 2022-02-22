using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace moment32.Models{

    // Class for records
    public class Record{

        [DisplayName("Skiva")]
        public int RecordId { get; set; }

        [Required(ErrorMessage = "Ange skivans titel")]
        [DisplayName("Skiva")]
        public string? RecordName { get; set; }

        [Required(ErrorMessage = "Du måste välja vilken artist det är")]
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}