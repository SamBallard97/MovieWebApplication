using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieWebApplication;
using Xunit;

namespace MovieIntegrationTests
{
    public class MovieIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private HttpClient _client { get; }

        public MovieIntegrationTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        //[Fact]
        //public async Task GetAllMovies_ReturnsList()
        //{
        //    //arrange + act
        //    var response = await _client.GetAsync("movies/all");

        //    //assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}
    }
}
