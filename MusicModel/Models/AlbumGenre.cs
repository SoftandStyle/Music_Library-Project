using System.Security.Policy;

namespace Music_Library.Models
{
    public class AlbumGenre
    {
        public int GenreID { get; set; }
        public int AlbumID { get; set; }
        public Genre Genre { get; set;}
        public Album Album { get; set; }
    }
}
