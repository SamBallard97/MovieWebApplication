using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieWebApplication.Controllers
{
    [ApiController]
    [Route("elephants")]
    public class ElephantController : ControllerBase
    {
        private readonly IElephantService _elephantService;
        private const string FILEPATH = "C:\\Users\\sam.ballard\\Documents\\Northcoders\\Files\\elephants.json";
        private const string FILEPATH_TEST = "C:\\Users\\sam.ballard\\Documents\\Northcoders\\Files\\elephantsTestData.json";

        public ElephantController(IElephantService elephantService)
        {
            _elephantService = elephantService;
        }

        [HttpGet]
        public List<Elephant> GetElephants(bool isTest)
        {
            var elephants = new List<Elephant>();

            if (isTest)
            {
                elephants = _elephantService.GetElephants(FILEPATH_TEST);
            }
            else
            {
                elephants = _elephantService.GetElephants(FILEPATH);
            }

            return elephants;
        }



        [HttpGet("{elephantId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Elephant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Elephant> GetElephant(Guid elephantId)
        {
            var elephant = _elephantService.GetElephants(FILEPATH).Where(x => x.Id == elephantId)?.FirstOrDefault() ?? null;

            if (elephant != null)
            {
                return Ok(elephant);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Elephant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddElephant([FromBody]ElephantRequest addElephantRequest)
        {
            var addedElephant = _elephantService.AddElephant(addElephantRequest, FILEPATH);

            if(addedElephant != null)
            {
                return Ok(addedElephant);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult DeleteElephant(Guid elephantId)
        {
            _elephantService.DeleteElephant(elephantId, FILEPATH);

            return NoContent();
        }

    }
}