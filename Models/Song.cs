using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace moment32.Models{
    // Class for song
    public class Song{

        [DisplayName("Låt")]
        public int SongId { get; set; }

        [Required(ErrorMessage = "Ange titeln på låten")]
        [DisplayName("Låt")]
        public string? SongName { get; set; }

        [Required(ErrorMessage = "Ange rätt skiva")]
        [DisplayName("Skiva")]
        public int RecordId { get; set; }

        [Required(ErrorMessage = "Ange rätt skiva")]
        [DisplayName("Skiva")]
        public Record? Record { get; set; }
    }
}