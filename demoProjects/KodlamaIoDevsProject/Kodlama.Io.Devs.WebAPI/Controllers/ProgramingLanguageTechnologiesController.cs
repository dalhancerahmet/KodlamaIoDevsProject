using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.CreateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.DeleteProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Commands.UpdateProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnologyByDynamic;
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
        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgramingLanguageTechnologyCommand deleteProgramingLanguageTechnologyCommand)
        {
            bool isDelete =await Mediator.Send(deleteProgramingLanguageTechnologyCommand);
            return Ok(isDelete);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageTechnologyCommand updateProgramingLanguageTechnologyCommand)
        {
           UpdatedProgramingLanguageTechnologyDto updatedTechnology= await Mediator.Send(updateProgramingLanguageTechnologyCommand);
            return Ok(updatedTechnology);
        }

        [HttpGet("getbydynamic")]
        public async Task<IActionResult> GetAllByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgramingLanguageTechnologyByDynamicQuery getListByDynamic= 
                new GetListProgramingLanguageTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
           ProgramingLanguageTechnologyListModel technology=await Mediator.Send(getListByDynamic);
            return Ok(technology);
        }

    }
}
