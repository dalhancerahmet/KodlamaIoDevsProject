using Core.Security.JWT;
using Kodlama.Io.Devs.Application.Features.Users.Commands.LoginUserCommand;
using Kodlama.Io.Devs.Application.Features.Users.Commands.RegisterUserCommand;
using Kodlama.Io.Devs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
           UserResponseDto userResponseDto= await Mediator.Send(registerUserCommand);
           return Created("", userResponseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            AccessToken token = await Mediator.Send(loginUserCommand);
            return Created("",token);
        }
    }
}
