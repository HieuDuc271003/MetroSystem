using MetroSystem.Service.Interface;
using MetroSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using MetroSystem.Data.Enities;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
     
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationModel loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { message = "Email and password are required" });
            }

            var token = await _authenticationService.AuthenticationLogin(loginRequest.Email, loginRequest.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(new { token });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var result = await _authenticationService.Register(registerDto);

            if (result == "Email already exists!")
            {
                return BadRequest(new { message = result });
            }

            return Ok(new { message = result });
        }
    }
}
