using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using System.Collections.Generic;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("elephants")]
    public class ElephantController
    {
        private readonly IElephantService _elephantService;

        public ElephantController(IElephantService elephantService)
        {
            _elephantService = elephantService;
        }

        [HttpGet]
        public List<Elephant> GetElephants()
        {
            var filepath = "test";
            var elephants = _elephantService.GetElephants(filepath);

            return elephants;
        }
    }
}
