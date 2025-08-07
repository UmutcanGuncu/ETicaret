using ETicaret.API.Validations;
using ETicaret.Application.CQRS.Commands.Auths;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, IValidator<RegisterUserCommandRequest> validator) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterUserCommandRequest request)
        {
            var result = await mediator.Send(request);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }

}
