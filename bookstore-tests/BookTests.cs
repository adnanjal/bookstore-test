using bookstore_migrations.Repositories;
using Moq;
using bookstore_migrations.Services;

namespace bookstore_tests;

public class BookTests
{
    [Fact]
    public async void AddBook_WithValidDetails_AddsBook()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        var book = new Book();
        book.AuthorId = 1;
        book.Title = "Test title";
        book.Description = "Test description";

        var service = new BookService(mockRepo.Object);

        // Act
        await service.Add(book);

        // Assert
        mockRepo.Verify(repo => repo.Add(book), Times.Once);
    }

    [Fact]
    public void GetAll_ReturnsBooks()
    {

    }

    [Fact]
    public void Add_Delete_ReturnsNoBooks()
    {

    }
}