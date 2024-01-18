using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Library.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int? ReviewID {  get; set; }
        public Review? Review { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }


        public ICollection<DownloadedAlbum>? DownloadedAlbums { get; set; }
    }
}
