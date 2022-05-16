using BlogYonetim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYonetim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login(string Email, string Password)
        {
            var author = _context.Author.FirstOrDefault(w => w.Email == Email && w.Password == Password);
            if (author == null)
            {
                return RedirectToAction(nameof(Index));

            }

            HttpContext.Session.SetInt32("id", author.id);

            return RedirectToAction(nameof(Category));
        }
        public async Task<IActionResult> AddAuthor(Author author)
        {
            
                await _context.AddAsync(author);
         
               await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Author));
        }
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public IActionResult Category()
        {

            List<Category> List = _context.Category.ToList();
            return View(List);
        }

        public IActionResult Author()
        {
            List<Author> list = _context.Author.ToList();
            return View(list);
        }

        public async Task<IActionResult> DeleteCategory(int? Id)
        {
            Category category = await _context.Category.FindAsync(Id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }

        public async Task<IActionResult> DeleteAuthor(int? Id)
        {
            var author = await _context.Author.FindAsync(Id);
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
