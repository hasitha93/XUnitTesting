using BookCollection.API.Controllers;
using BookCollection.DataAccess.Entities;
using BookCollection.DataAccess.Repositories;
using BookCollection.UnitTests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookCollection.UnitTests.Controllers
{
    public class TestBookController
    {
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly BookController _controller;

        public TestBookController()
        {
            _mockRepo = new Mock<IBookRepository>();
            _controller = new BookController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnOkResult()
        {
            //Arrange
            _mockRepo.Setup(_ => _.GetListAsync()).ReturnsAsync(BookMockData.GetBookList());

            //Act
            var result = await _controller.GetAllBooksAsync();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnNoContent()
        {
            //Arrange
            _mockRepo.Setup(_ => _.GetListAsync()).ReturnsAsync(BookMockData.GetEmptyBookList());

            //Act
            var result = await _controller.GetAllBooksAsync();

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task GetBookByIdAsync_ExistingIdPassed_ShouldReturnOKRequest()
        {
            /// Arrange
            long isbn13 = 1234567890111;
            _mockRepo.Setup(_ => _.GetByIsbnAsync(It.IsAny<long>())).
                ReturnsAsync((long i) => BookMockData.GetBookList().SingleOrDefault(p => p.Isbn13 == i));

            /// Act
            var result = await _controller.GetBookByIdAsync(isbn13);

            /// Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetBookByIdAsync_NotExistingIdPassed_ShouldReturnBadRequest()
        {
            /// Arrange
            long isbn13 = 1234567890555;
            _mockRepo.Setup(_ => _.GetByIsbnAsync(It.IsAny<long>())).
                ReturnsAsync((long i) => BookMockData.GetBookList().SingleOrDefault(p => p.Isbn13 == i));

            /// Act
            var result = await _controller.GetBookByIdAsync(isbn13);

            /// Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task AddBookAsync_ShouldCall_AddAsync_ExactlyOnce()
        {
            /// Arrange
            var newBook = BookMockData.NewBookModel();

            /// Act
            var result = await _controller.AddBookAsync(newBook);

            /// Assert
            _mockRepo.Verify(_ => _.AddAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}
