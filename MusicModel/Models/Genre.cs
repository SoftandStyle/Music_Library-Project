using System.ComponentModel.DataAnnotations;

namespace Music_Library.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}
