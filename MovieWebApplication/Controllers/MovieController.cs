using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("Greeting")]
        public string GetWelcomeMessage()
        {
            var timestamp = DateTime.Now;

            return "Welcome to my movie collection. You've connected at " + timestamp;
        }


        [HttpGet("all")]
        public List<Movie> GetAllMovies()
        {
            return _movieService.GetAllMovies();
        }

    }
}
