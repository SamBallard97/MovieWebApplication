using AutoMapper;
using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MovieWebApplication.Services
{
    public class ElephantService : IElephantService
    {

        private readonly IMapper _mapper;

        public ElephantService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Elephant> GetElephants(string filepath)
        {
            var jsonString = File.ReadAllText(filepath);
            var elephants = JsonSerializer.Deserialize<List<Elephant>>(jsonString);

            return elephants;
        }

        public Elephant AddElephant(ElephantRequest elephantToAdd, string filepath)
        {
            // Convert to Model
            var elephant = _mapper.Map<Elephant>(elephantToAdd);
            elephant.Id = Guid.NewGuid();

            // Add to List
            var elephants = GetElephants(filepath);
            elephants.Add(elephant);

            // Conver to Json & Write to file
            var json = JsonSerializer.Serialize(elephants);
            File.WriteAllText(filepath, json);

            return elephant;
        }

        public void DeleteElephant(Guid elephantId, string filepath)
        {
            // Get list of Elephants
            var elephants = GetElephants(filepath);
            elephants.RemoveAll(x => x.Id == elephantId);

            // Convert to Json & Write to file
            var json = JsonSerializer.Serialize(elephants);
            File.WriteAllText(filepath, json);
        }
    }
}
