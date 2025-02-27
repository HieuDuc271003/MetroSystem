using MetroSystem.Service.Interface;
using MetroSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using MetroSystem.Data.Enities;
using FirebaseAdmin.Auth;

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

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            try
            {
                var user = await _authenticationService.AuthenticateWithGoogleAsync(request.FirebaseUid, request.Email, request.Name);

                if (user != null)
                {
                    return Ok(new { Message = "Login successful", User = user });
                }
                else
                {
                    return Unauthorized(new { Message = "User authentication failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }
    }
}
