using Microsoft.EntityFrameworkCore;
using Music_Library.Models;

namespace Music_Library.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<DownloadedAlbum> DownloadedAlbums { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<DownloadedAlbum>().ToTable("DownloadedAlbum");
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<AlbumGenre>().ToTable("AlbumGenre");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Review>().ToTable("Review");

            modelBuilder.Entity<AlbumGenre>()
                            .HasKey(c => new { c.AlbumID, c.GenreID });



        }
    }

   
}
