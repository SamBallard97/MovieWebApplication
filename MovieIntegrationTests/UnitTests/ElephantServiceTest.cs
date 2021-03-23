using AutoMapper;
using Moq;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MovieWebApplicationTests.UnitTests
{
    public class ElephantServiceTest
    {
        public Mock<IMapper> _mapperMock;
        public const string FILEPATH_TEST = "C:\\Users\\sam.ballard\\Documents\\Northcoders\\Files\\elephantsTestData.json";

        public ElephantServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
        }

    }

    public class GetElephantsTest : ElephantServiceTest
    {
        [Fact]
        public async Task GetElephants_Returns()
        {
            // arrange
            var service = new ElephantService(_mapperMock.Object);

            // act
            var elephants = await service.GetElephants(FILEPATH_TEST);

            // assert
            Assert.NotNull(elephants);
            Assert.IsType<List<Elephant>>(elephants);
            Assert.True(elephants.Count == 25);
        }

        [Fact]
        public async Task GetElephants_ReturnsInvalidString()
        {
            // arrange
            var service = new ElephantService(_mapperMock.Object);

            // act
            var ex = await Assert.ThrowsAsync<FileNotFoundException>(() => service.GetElephants("fake"));

            // assert
            Assert.Equal("Could not find file 'C:\\Users\\sam.ballard\\source\\repos\\MovieWebApplication\\MovieIntegrationTests\\bin\\Debug\\netcoreapp3.1\\fake'.", ex.Message);
        }
    }
}

