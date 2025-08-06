using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController() : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login()
        {
            
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register()
        {
            
          
            return Ok();
        }
    }

}
