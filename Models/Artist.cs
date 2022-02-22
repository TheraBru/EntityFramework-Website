
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace moment32.Models{
    // Class for Artists
    public class Artist{
        
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Ange artistens namn")]
        [DisplayName("Artist")]
        public string? ArtistName { get; set; }
        public List<Record>? Records { get; set; }
    }
}