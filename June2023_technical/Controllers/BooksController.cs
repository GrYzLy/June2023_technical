using Microsoft.AspNetCore.Mvc;
using June2023_technical.Models;
using June2023_technical.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace June2023_technical.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching books.");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.AddBookAsync(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while creating a new book.");
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting a book.");
                ModelState.AddModelError("", "Unable to delete the book. Try again, and if the problem persists, see your system administrator.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
