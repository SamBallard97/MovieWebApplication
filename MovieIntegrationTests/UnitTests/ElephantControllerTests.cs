using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieWebApplication.Controllers;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace MovieWebApplicationTests.UnitTests
{
    public class ElephantControllerTests
    {
        public Mock<IElephantService> _elephantService;

        public ElephantControllerTests()
        {
            _elephantService = new Mock<IElephantService>();
        }
    }

    public class ElephantControllerGetTests : ElephantControllerTests
    {
        [Fact]
        public void GetElephants_ReturnsList()
        {
            var elephants = new List<Elephant>()
            {
                new Elephant()
                {
                    Name = "Sam",
                    Dob = 100,
                    Dod = 101
                }
            };


            // arrange
            _elephantService.Setup(x => x.GetElephants(It.IsAny<string>())).Returns(elephants);
            var controller = new ElephantController(_elephantService.Object);


            // act
            var result = controller.GetElephants(true);

            // assert
            Assert.NotNull(result);
            Assert.Equal(elephants, result);

        }

        [Fact]
        public void GetElephant_ReturnsOne()
        {
            //arrange
            var searchedGuid = Guid.NewGuid();
            var correctElephant = new Elephant()
            {
                Name = "Sam",
                Id = searchedGuid,
                Note = "This is the elephant we want to get"
            };
            var incorrectElephant1 = new Elephant()
            {
                Name = "Barry",
                Id = Guid.NewGuid(),
                Note = "This is NOT the elephant we want to get"
            };
            var incorrectElephant2 = new Elephant()
            {
                Name = "Steve",
                Id = Guid.NewGuid(),
                Note = "This is NOT the elephant we want to get"
            };

            var elephantList = new List<Elephant>();
            elephantList.Add(correctElephant);
            elephantList.Add(incorrectElephant1);
            elephantList.Add(incorrectElephant2);
            var controller = new ElephantController(_elephantService.Object);
            _elephantService.Setup(x => x.GetElephants(It.IsAny<string>())).Returns(elephantList);

            //act
            var response = controller.GetElephant(searchedGuid);
            var result = (OkObjectResult)response.Result;

            //assert
            Assert.NotNull(result.Value);
            Assert.Equal(correctElephant, result.Value);
            Assert.True(result is OkObjectResult);
            Assert.IsType<Elephant>(result.Value);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void GetElephant_ReturnsNull()
        {
            //arrange
            var searchedGuid = Guid.NewGuid();
            var incorrectElephant1 = new Elephant()
            {
                Name = "Barry",
                Id = Guid.NewGuid(),
                Note = "This is NOT the elephant we want to get"
            };
            var incorrectElephant2 = new Elephant()
            {
                Name = "Steve",
                Id = Guid.NewGuid(),
                Note = "This is NOT the elephant we want to get"
            };

            var elephantList = new List<Elephant>();
            elephantList.Add(incorrectElephant1);
            elephantList.Add(incorrectElephant2);
            var controller = new ElephantController(_elephantService.Object);
            _elephantService.Setup(x => x.GetElephants(It.IsAny<string>())).Returns(elephantList);

            //act
            var response = controller.GetElephant(searchedGuid);
            var result = (NotFoundResult)response.Result;

            //assert
            Assert.Equal(404, result.StatusCode);

            Assert.NotNull(result);
            Assert.True(result is NotFoundResult);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GetElephant_OnEmptyList()
        {
            //arrange
            var elephantList = new List<Elephant>();
            var controller = new ElephantController(_elephantService.Object);
            _elephantService.Setup(x => x.GetElephants(It.IsAny<string>())).Returns(elephantList);

            //act
            var response = controller.GetElephant(Guid.NewGuid());
            var result = (NotFoundResult)response.Result;

            //assert
            Assert.Equal(404, result.StatusCode);

            Assert.NotNull(result);
            Assert.True(result is NotFoundResult);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
