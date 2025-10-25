using Microsoft.AspNetCore.Mvc;
using Security.Models.DTOS;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id = result }, null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var (ok,token) = await _service.LoginAsync(dto);
            if (!ok)
            {
                return Unauthorized();
            }
            return Ok(new {access_token=token, token_type="Bearer"});
        }
    }
}
