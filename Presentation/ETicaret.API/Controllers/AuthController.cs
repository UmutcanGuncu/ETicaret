using ETicaret.Application.CQRS.Commands.Auths;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            var result = await mediator.Send(request);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }

}
