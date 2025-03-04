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
                if (request == null || string.IsNullOrEmpty(request.FirebaseUid) || string.IsNullOrEmpty(request.Email))
                {
                    return BadRequest(new { Message = "Dữ liệu đầu vào không hợp lệ" });
                }

                var (user, token) = await _authenticationService.AuthenticateWithGoogleAsync(request.FirebaseUid, request.Email, request.Name);

                if (user != null)
                {
                    return Ok(new { Message = "Login successful", User = user, Token = token });
                }
                else
                {
                    return Unauthorized(new { Message = "User authentication failed" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Google Login Error: {ex.Message}"); // Log lỗi chi tiết hơn
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }
    }
}
