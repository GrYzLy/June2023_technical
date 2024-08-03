using Microsoft.AspNetCore.Mvc;
using June2023_technical.Models;
using Serilog;

namespace June2023_technical.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving books.");
                return View("Error", new ErrorViewModel { Exception = ex });
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,PublicationYear,Genre,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepository.AddBookAsync(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error occurred while creating a book.");
                    return View("Error", new ErrorViewModel { Exception = ex });
                }
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id.Value);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving book for deletion.");
                return View("Error", new ErrorViewModel { Exception = ex });
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _bookRepository.DeleteBookAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while deleting a book.");
                return View("Error", new ErrorViewModel { Exception = ex });
            }
        }
    }
}
