using June2023_technical.Data;
using June2023_technical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace June2023_technical.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Loading book list.");
                var books = await _context.Books.ToListAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading the book list.");
                return View("Error");
            }
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Book ID is null.");
                return NotFound();
            }

            try
            {
                var book = await _context.Books
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Displaying details for book with ID {id}.");
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book details.");
                return View("Error");
            }
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,PublicationYear,Genre,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Created new book with ID {Id}.", book.Id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating a new book.");
                }
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Book ID is null.");
                return NotFound();
            }

            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Editing book with ID {id}.");
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book for editing.");
                return View("Error");
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,PublicationYear,Genre,Price")] Book book)
        {
            if (id != book.Id)
            {
                _logger.LogWarning("Book ID mismatch during edit operation.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Updated book with ID {Id}.", book.Id);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!BookExists(book.Id))
                    {
                        _logger.LogWarning($"Book with ID {book.Id} not found during update.");
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError(ex, "An error occurred while updating the book.");
                        throw;
                    }
                }
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Book ID is null.");
                return NotFound();
            }

            try
            {
                var book = await _context.Books
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Displaying delete confirmation for book with ID {id}.");
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book for deletion.");
                return View("Error");
            }
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Deleted book with ID {Id}.", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book.");
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
