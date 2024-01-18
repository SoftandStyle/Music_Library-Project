using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Library.Models
{
    public class DownloadedAlbum
    {
        public int DownloadedAlbumID { get; set; }
        public int UserID { get; set; }
        public int AlbumID { get; set;}

        public string Method {  get; set; }

        public User? User { get; set; }
        public Album? Album { get; set; }
    }
}
