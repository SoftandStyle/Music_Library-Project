using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Library.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }
        public int? ArtistID { get; set; }
        public  Artist? Artist { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public ICollection<DownloadedAlbum>? DownloadedAlbums { get; set; }
        public ICollection<AlbumGenre>? AlbumsGenres { get; set; }



    }
}
