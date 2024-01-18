using Microsoft.EntityFrameworkCore;
using Music_Library.Models;
using System.Security.Policy;

namespace Music_Library.Data
{
    public class Database
    {
        public static void Initialize(IServiceProvider serviceProvider) {

            using (var context = new MusicContext(serviceProvider.GetRequiredService<DbContextOptions<MusicContext>>())) { 
            
            if (context.Albums.Any())
                {
                    return;
                }


                var reviews = new Review[]
                {
                new Review{Comment = "Extraordinar album."},
                new Review{Comment = "L-as mai asculta o data."},
                new Review{Comment = "Am ramas uimit."},
                new Review{Comment = "Cand scoateti urmatorul album?"},
                new Review{Comment = "Vreau sa merg si la concert."}
                };
                foreach(Review r in reviews) {

                    context.Reviews.Add(r);
                
                }
                
                context.SaveChanges();

                var artists = new Artist[]
                {
                    new Artist{Name = "Metallica"},
                    new Artist{Name = "Eminem"},
                    new Artist{Name = "Bob Marley"},
                    new Artist{Name = "Phoenix"},
                    new Artist{Name = "Ghostmane"}
                };
                foreach (Artist a in artists)
                {

                    context.Artists.Add(a);

                }
                
                context.SaveChanges();

                var albums = new Album[]
                {
                    new Album{AlbumName = "Master of Puppets", Price = Decimal.Parse("10"), ArtistID = artists[0].ID},
                    new Album{AlbumName = "Kill 'Em All", Price = Decimal.Parse("7"), ArtistID = artists[0].ID},
                    new Album{AlbumName = "Kamikaze", Price = Decimal.Parse("8"), ArtistID = artists[1].ID},
                    new Album{AlbumName = "Get The Guns", Price = Decimal.Parse("9"), ArtistID = artists[1].ID},
                    new Album{AlbumName = "Young Mystic", Price = Decimal.Parse("6"), ArtistID = artists[2].ID},
                    new Album{AlbumName = "Interviews", Price = Decimal.Parse("5"), ArtistID = artists[2].ID},
                    new Album{AlbumName = "In umbra marelui urs", Price = Decimal.Parse("4"), ArtistID = artists[3].ID},
                    new Album{AlbumName = "Mugur de fluier", Price = Decimal.Parse("3"), ArtistID = artists[3].ID},
                    new Album{AlbumName = "Hexada", Price = Decimal.Parse("2"), ArtistID = artists[4].ID},
                    new Album{AlbumName = "N/O/I/S/E", Price = Decimal.Parse("2"), ArtistID = artists[4].ID}
                };
                foreach (Album a in albums)
                {

                    context.Albums.Add(a);

                }
                
                context.SaveChanges();

                var users = new User[]
                {
                    new User{Name = "bestseller28", Email = "bestsell@gmail.com", Age = 22},
                    new User{Name = "alexanik1999", Email = "alexmihai@gmail.com", Age = 20},
                    new User{Name = "musicaddicted01", Email = "laviniapop@gmail.com", Age = 19},
                    new User{Name = "nutucarutu4943", Email = "marianandrei@gmail.com", Age = 18},
                    new User{Name = "copypaste5893", Email = "copsamica@gmail.com", Age = 30},
                };
                foreach (User u in users)
                {

                    context.Users.Add(u);

                }
                
                context.SaveChanges();

                var downloadedalbums = new DownloadedAlbum[]{

                    new DownloadedAlbum { AlbumID = 2, UserID = 1, Method = "uTorent" },
                    new DownloadedAlbum { AlbumID = 9, UserID = 2, Method = "winrar" },
                    new DownloadedAlbum { AlbumID = 3, UserID = 2, Method = "uTorent" },
                    new DownloadedAlbum { AlbumID = 4, UserID = 3, Method = "winrar" },
                    new DownloadedAlbum { AlbumID = 5, UserID = 4, Method = "uTorent" },
                    new DownloadedAlbum { AlbumID = 7, UserID = 5, Method = "winrar" }
                    

                };
                foreach (DownloadedAlbum d in downloadedalbums)
                {

                    context.DownloadedAlbums.Add(d);

                }
                
                context.SaveChanges();

                var genres = new Genre[]
                {
                    new Genre{Name = "Metal"},
                    new Genre{Name = "Rap"},
                    new Genre{Name = "Trap"},
                    new Genre{Name = "Raggae"},
                    new Genre{Name = "Rock"},
                };
                foreach (Genre g in genres)
                {

                    context.Genres.Add(g);

                }
                
                context.SaveChanges();

                var albumgenres = new AlbumGenre[]
                {
                    new AlbumGenre{AlbumID = albums[0].ID, GenreID = genres[0].ID},
                    new AlbumGenre{AlbumID = albums[1].ID, GenreID = genres[2].ID},
                    new AlbumGenre{AlbumID = albums[2].ID, GenreID = genres[3].ID},
                    new AlbumGenre{AlbumID = albums[7].ID, GenreID = genres[4].ID},
                    new AlbumGenre{AlbumID = albums[9].ID, GenreID = genres[1].ID},
                    new AlbumGenre{AlbumID = albums[5].ID, GenreID = genres[3].ID},
                    new AlbumGenre{AlbumID = albums[6].ID, GenreID = genres[2].ID}
                };
                foreach (AlbumGenre ag in albumgenres)
                {

                    context.AlbumGenres.Add(ag);

                }
                
                context.SaveChanges();
            }


        }
    }
}
