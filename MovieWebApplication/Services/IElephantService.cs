using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public interface IElephantService
    {
        Task<List<Elephant>> GetElephants(string filepath);
        Elephant AddElephant(ElephantRequest elephantToAdd, string filepath);
        void DeleteElephant(Guid elepgantId, string filepath);
    }
}
