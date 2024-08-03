using June2023_technical.Models;
using Microsoft.EntityFrameworkCore;


namespace June2023_technical.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, Genre = "Fiction", Price = 10.99m },
                new Book { Id = 2, Title = "1984", Author = "George Orwell", PublicationYear = 1949, Genre = "Dystopian", Price = 9.99m },
                new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationYear = 1813, Genre = "Romance", Price = 12.99m },
                new Book { Id = 4, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, Genre = "Fiction", Price = 14.99m },
                new Book { Id = 5, Title = "Moby Dick", Author = "Herman Melville", PublicationYear = 1851, Genre = "Adventure", Price = 15.99m },
                new Book { Id = 6, Title = "War and Peace", Author = "Leo Tolstoy", PublicationYear = 1869, Genre = "Historical Fiction", Price = 20.99m },
                new Book { Id = 7, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationYear = 1951, Genre = "Fiction", Price = 10.99m },
                new Book { Id = 8, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationYear = 1937, Genre = "Fantasy", Price = 13.99m },
                new Book { Id = 9, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", PublicationYear = 1866, Genre = "Philosophical Fiction", Price = 16.99m },
                new Book { Id = 10, Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", PublicationYear = 1880, Genre = "Philosophical Fiction", Price = 18.99m }
            );
        }
    }
}
