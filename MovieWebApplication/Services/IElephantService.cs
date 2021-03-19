using MovieWebApplication.Models;
using System.Collections.Generic;

namespace MovieWebApplication.Services
{
    public interface IElephantService
    {
        List<Elephant> GetElephants(string filepath);
    }
}
