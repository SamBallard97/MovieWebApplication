using MovieWebApplication.Models;
using System;
using System.Collections.Generic;

namespace MovieWebApplication.Services
{
    public interface IElephantService
    {
        List<Elephant> GetElephants(string filepath);
        Elephant AddElephant(ElephantRequest elephantToAdd, string filepath);
        void DeleteElephant(Guid elepgantId, string filepath);
    }
}
