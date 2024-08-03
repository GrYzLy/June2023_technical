using System.Linq;
using System.Threading.Tasks;
using June2023_technical.Models;

namespace June2023_technical.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(BookContext context)
        {
            if (context.Books.Any())
            {
                return; 
            }

            var books = new Book[]
            {
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, Genre = "Fiction", Price = 7.99m },
                new Book { Title = "1984", Author = "George Orwell", PublicationYear = 1949, Genre = "Dystopian", Price = 9.99m },
                new Book { Title = "Moby-Dick", Author = "Herman Melville", PublicationYear = 1851, Genre = "Adventure", Price = 11.99m },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, Genre = "Fiction", Price = 10.99m },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", PublicationYear = 1813, Genre = "Romance", Price = 8.99m },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationYear = 1951, Genre = "Fiction", Price = 12.99m },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationYear = 1937, Genre = "Fantasy", Price = 13.99m },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", PublicationYear = 1932, Genre = "Dystopian", Price = 14.99m },
                new Book { Title = "Catch-22", Author = "Joseph Heller", PublicationYear = 1961, Genre = "Satire", Price = 15.99m },
                new Book { Title = "Little Women", Author = "Louisa May Alcott", PublicationYear = 1868, Genre = "Classic", Price = 7.49m }
            };

            context.Books.AddRange(books);
            await context.SaveChangesAsync();
        }
    }
}
