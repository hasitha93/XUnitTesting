using BookCollection.API.Controllers;
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
    }
}
