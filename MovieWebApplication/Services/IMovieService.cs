using System.Collections.Generic;

namespace MovieWebApplication
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
    }
}
