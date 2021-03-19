using System;

namespace MovieWebApplication
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}
