using ApiJWT.Models;
using ApiJWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiJWT.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);

            if(!result.IsAuthenticated)
            {
                return BadRequest(new { Message = result.Message });
            }

            return Ok(result);
        }
    }
}
