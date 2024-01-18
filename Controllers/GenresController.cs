using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Library.Data;
using Music_Library.Models;
using Music_Library.Models.MusicViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Music_Library.Controllers
{
    [Authorize(Policy = "SalesManager")]
    [Authorize(Policy = "OnlySales")]
    public class GenresController : Controller
    {
        private readonly MusicContext _context;

        public GenresController(MusicContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index(int? id, int? albumID)
        {
            var viewModel = new GenreIndexData();
            viewModel.Genres = await _context.Genres
                .Include(i => i.AlbumGenres)
                .ThenInclude(i => i.Album)
                .ThenInclude(i => i.DownloadedAlbums)
                .ThenInclude(i => i.User)
                .AsNoTracking()
                .OrderBy(i => i.Name)
                .ToListAsync();

            if (id != null) {

                ViewData["GenreID"] = id.Value;
                Genre genre = viewModel.Genres.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Albums = genre.AlbumGenres.Select(s => s.Album);

            }
            if (albumID != null)
            {
                ViewData["AlbumID"] = albumID.Value;
                viewModel.DownloadedAlbums = viewModel.Albums.Where(
                    x => x.ID == albumID).Single().DownloadedAlbums;
            }
            return View(viewModel);
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .Include(i => i.AlbumGenres).ThenInclude(i => i.Album)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }
            PopulateAlbumGenreData(genre);
            return View(genre);
        }
        private void PopulateAlbumGenreData(Genre genre)
        {
            var allAlbums = _context.Albums;
            var albumGenres = new HashSet<int>(genre.AlbumGenres.Select(c => c.AlbumID));
            var viewModel = new List<AlbumGenreData>();

            foreach (var album in allAlbums)
            {
                viewModel.Add(new AlbumGenreData
                {
                    AlbumID = album.ID,
                    AlbumName = album.AlbumName,
                    IsPicked = albumGenres.Contains(album.ID)
                });

                ViewData["Albums"] = viewModel;
            }


        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedAlbums)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreToUpdate = await _context.Genres
                .Include(i => i.AlbumGenres)
                .ThenInclude(i => i.Album)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<Genre>(genreToUpdate, "", i => i.Name))
            {
                UpdateAlbumGenres(selectedAlbums, genreToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */) {

                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists, ");

                }
                return RedirectToAction(nameof(Index));
            }
            UpdateAlbumGenres(selectedAlbums, genreToUpdate);
            PopulateAlbumGenreData(genreToUpdate);
            return View(genreToUpdate);
        }

        private void UpdateAlbumGenres(string[] selectedAlbums, Genre genreToUpdate)
        {
            if (selectedAlbums == null)
            {
                genreToUpdate.AlbumGenres = new List<AlbumGenre>();
                return;
            }

            var selectedAlbumsHS = new HashSet<string>(selectedAlbums);
            var albumGenres = new HashSet<int>
                (genreToUpdate.AlbumGenres.Select(c => c.Album.ID));
            foreach (var album in _context.Albums)
            {
                if (selectedAlbumsHS.Contains(album.ID.ToString()))
                {
                    if (!albumGenres.Contains(album.ID))
                    {

                        genreToUpdate.AlbumGenres.Add(new AlbumGenre { GenreID = genreToUpdate.ID, AlbumID = album.ID });

                    }
                }
                else
                {

                    if (albumGenres.Contains(album.ID))
                    {
                        AlbumGenre albumToRemove = genreToUpdate.AlbumGenres.FirstOrDefault(i => i.AlbumID == album.ID);
                        _context.Remove(albumToRemove);
                    }


                }
            }

        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Genres == null)
            {
                return Problem("Entity set 'MusicContext.Genres'  is null.");
            }
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
          return (_context.Genres?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
