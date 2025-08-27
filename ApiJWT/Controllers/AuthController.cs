﻿using ApiJWT.Models;
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
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);

            if(!result.IsAuthenticated)
            {
                return BadRequest(new {result.Message });
            }

            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
            {
                return BadRequest(new {result.Message });
            }

            return Ok(result);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(new { Message = result });
            return Ok(model);

        }
    }
}
