using System.Security.Policy;
using Music_Library.Models;

namespace Music_Library.Models.MusicViewModels
{
    public class GenreIndexData
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<DownloadedAlbum> DownloadedAlbums { get; set; }
    }
}
