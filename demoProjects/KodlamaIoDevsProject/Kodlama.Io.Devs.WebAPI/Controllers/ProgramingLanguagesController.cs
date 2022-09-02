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
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createBrandCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }
    }
}
