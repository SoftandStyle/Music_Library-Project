namespace Music_Library.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; } 
        
    }
}
