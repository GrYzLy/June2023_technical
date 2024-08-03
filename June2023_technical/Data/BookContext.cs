using June2023_technical.Models;
using Microsoft.EntityFrameworkCore;


namespace June2023_technical.Data
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
