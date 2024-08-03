using Moq;
using Microsoft.AspNetCore.Mvc;
using June2023_technical.Controllers;
using June2023_technical.Models;


public class BooksControllerTests
{
    private BooksController CreateController()
    {
        
        var mockRepo = new Mock<IBookRepository>();

        
        mockRepo.Setup(repo => repo.GetAllBooksAsync()).ReturnsAsync(GetTestBooks());

        
        return new BooksController(mockRepo.Object);
    }

    [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfBooks()
    {
        
        var controller = CreateController();

        
        var result = await controller.Index() as ViewResult;

        
        Assert.NotNull(result);
        var model = Assert.IsAssignableFrom<List<Book>>(result.Model);
        Assert.Equal(2, model.Count);
    }

    private List<Book> GetTestBooks()
    {
        return new List<Book>
        {
            new Book { Id = 1, Title = "Book1", Author = "Author1", PublicationYear = 2020, Genre = "Fiction", Price = 9.99M },
            new Book { Id = 2, Title = "Book2", Author = "Author2", PublicationYear = 2021, Genre = "Non-Fiction", Price = 19.99M }
        };
    }
}
