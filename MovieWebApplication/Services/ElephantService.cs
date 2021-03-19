using MovieWebApplication.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MovieWebApplication.Services
{
    public class ElephantService : IElephantService
    {
        public List<Elephant> GetElephants(string filepath)
        {
            var jsonString = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<Elephant>>(jsonString);
        }
    }
}
