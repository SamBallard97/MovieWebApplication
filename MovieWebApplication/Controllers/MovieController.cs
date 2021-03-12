using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController
    {
        private IMovieService _movie;

        public MovieController(IMovieService movie)
        {
            _movie = movie;
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
            return _movie.GetAllMovies();
        }

    }
}
