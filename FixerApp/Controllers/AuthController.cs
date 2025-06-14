using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResponse { Success = false, Message = "Invalid data." });

            var result = await _authService.RegisterAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResponse { Success = false, Message = "Invalid data." });

            var result = await _authService.LoginAsync(dto);
            if (!result.Success)
                return Unauthorized(result); 

            return Ok(result);
        }
    }
}
