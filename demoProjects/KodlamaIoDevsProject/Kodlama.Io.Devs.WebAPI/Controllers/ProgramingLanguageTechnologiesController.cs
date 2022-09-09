using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.CreateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageTechnologiesController : BaseController
    {
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageTechnologyQuery getListProgramingLanguageTechnologyQuery = new GetListProgramingLanguageTechnologyQuery { PageRequest = pageRequest };
            ProgramingLanguageTechnologyListModel result = await Mediator.Send(getListProgramingLanguageTechnologyQuery);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProgramingLanguageTechnologyCommand createProgramingLanguageTechnologyCommand)
        {
            CreatedProgramingLanguageTechnologyDto technology= await Mediator.Send(createProgramingLanguageTechnologyCommand);
           return Created("", technology);
        }
    }
}
