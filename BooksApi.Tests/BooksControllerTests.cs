using June2023_technical.Controllers;
using June2023_technical.Data;
using June2023_technical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class BooksControllerTests
{
    private readonly BooksController _controller;
    private readonly BookContext _context;

    public BooksControllerTests()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "BooksTestDatabase")
            .Options;
        _context = new BookContext(options);

        _context.Books.AddRange(
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, Genre = "Fiction", Price = 10.99m },
            new Book { Title = "1984", Author = "George Orwell", PublicationYear = 1949, Genre = "Dystopian", Price = 9.99m }
        );
        _context.SaveChanges();

        _controller = new BooksController(_context);
    }

    [Fact]
    public void Index_ReturnsAViewResult_WithAListOfBooks()
    {
        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public void Create_ReturnsAViewResult()
    {
        // Act
        var result = _controller.Create();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Create_AddsBookAndRedirects()
    {
        // Arrange
        var newBook = new Book
        {
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            Genre = "Fiction",
            Price = 14.99m
        };

        // Act
        var result = _controller.Create(newBook);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        Assert.Equal(3, _context.Books.Count());
    }
}
