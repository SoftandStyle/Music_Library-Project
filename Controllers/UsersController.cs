using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Library.Data;
using Music_Library.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

using static System.Net.WebRequestMethods;

namespace Music_Library.Controllers
{
    public class UsersController : Controller
    {
        private readonly MusicContext _context;
        private string _baseUrl = "http://localhost:5075/api/Users";
        public UsersController(MusicContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var customers = JsonConvert.DeserializeObject<List<User>>(await
                response.Content.
                ReadAsStringAsync());
                return View(customers);
            }
            return NotFound();
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var user = await _context.Users.AsNoTracking().Include(b => b.Review)
                    .FirstOrDefaultAsync(m => m.UserID == id);
                return View(user);
            }
            return NotFound();
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["ReviewID"] = new SelectList(_context.Reviews, "ID", "Comment");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Name, Email, ReviewID")] User user)
        {
            ViewData["ReviewID"] = new SelectList(_context.Reviews, "ID", "Comment");
            if (!ModelState.IsValid) return View(user);
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(user);
                var response = await client.PostAsync(_baseUrl,
                new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record:{ex.Message}");
            }
            return View(user);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ReviewID"] = new SelectList(_context.Reviews, "ID", "Comment");
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(s => s.UserID == id);
            ViewData["ReviewID"] = new SelectList(_context.Reviews, "ID", "Comment");

            if (await TryUpdateModelAsync<User>(
                userToUpdate,
                "",
                s => s.Name, s => s.Email, s => s.Review))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists");
                }
            }
            return View(userToUpdate);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var user = await _context.Users.Include(b => b.Review).AsNoTracking()
                    .FirstOrDefaultAsync(m => m.UserID == id);
                return View(user);
            }
            return new NotFoundResult();
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("CustomerID")] User user)
        {
            try
            {
                var client = new HttpClient();
                HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Delete,
                $"{_baseUrl}/{user.UserID}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to delete record:{ex.Message}");
            }
            return View(user);
        }

        private bool CustomerExists(int id)
        {
            return (_context.Users?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
    }
}