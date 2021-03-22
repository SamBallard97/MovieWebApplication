using Moq;
using MovieWebApplication;
using MovieWebApplication.Controllers;
using System;
using Xunit;

namespace MovieWebApplicationTests.UnitTests
{
    public class MovieControllerTests
    {
        public Mock<IMovieService> _movieService;

        public MovieControllerTests()
        {
            _movieService = new Mock<IMovieService>();
        }
    }

    public class MovieControllerGetTests : MovieControllerTests
    {
        [Fact]
        public void GetElephants_ReturnsList()
        {
            // arrange
            var controller = new MovieController(_movieService.Object);
            var dateTime = DateTime.Now;

            // act
            var result = controller.GetWelcomeMessage();

            // assert
            Assert.Equal("Welcome to my movie collection. You've connected at " + dateTime, result) ;
        }
    }
}
