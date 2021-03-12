using System;
using System.Collections.Generic;

namespace MovieWebApplication
{
    public class Movie : IMovie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }

        public List<Movie> GetAllMovies()
        {
            var movieList = new List<Movie>()
            {
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Harry Potter",
                    ReleaseYear = 1996,
                    Rating = 2
                },

                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Over The Hedge",
                    ReleaseYear = 2006,
                    Rating = 5
                },

                new Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "Star Wars",
                    ReleaseYear = 1971,
                    Rating = 3
                },
            };

            return movieList;
        }
    }
}
