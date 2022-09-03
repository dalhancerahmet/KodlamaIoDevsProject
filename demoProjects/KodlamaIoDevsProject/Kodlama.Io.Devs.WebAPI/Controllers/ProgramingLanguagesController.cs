using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest )
        {
            GetListProgramingLanguageQuery query = new() { PageRequest = pageRequest };
           ProgramingLanguageListModel result= await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
           ProgramingLanguageGetByIdDto programingLanguage= await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(programingLanguage);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createBrandCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeletedProgramingLanguageDto result= await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdatedProgramingLanguageDto updatedProgramingLanguageDto=await Mediator.Send(updateProgramingLanguageCommand);
            return Created("",updatedProgramingLanguageDto);
        }
    }
}
