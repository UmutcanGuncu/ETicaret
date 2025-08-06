using ETicaret.Application.DTOs.Auths.Requests;
using ETicaret.Domain.Entities;
using ETicaret.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login()
        {
            
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            
            AppUser user = new()
            {
                Id  = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.Email
                
            };
            var result = await userManager.CreateAsync(user, dto.Password);
            return Ok(result);
        }
    }

}
