using bookstore_migrations.Repositories;
using bookstore_migrations.Services;
using Moq;

namespace bookstore_tests;

public class BookTests
{
    [Fact]
    public async void AddBook_WithValidDetails_AddsBook()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository>();
        var book = new Book(1, title: "Title", description: "Description", author: new Author(1, "First", "Last", "FL"));
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