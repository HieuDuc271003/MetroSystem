using MetroSystem.Service.Interface;
using MetroSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using MetroSystem.Data.Enities;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ItokenService _tokenService;

        public AuthController(IAuthenticationService authenticationService, ItokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] AuthenticationModel request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.IdToken))
                {
                    return BadRequest(new { Message = "Thiếu IdToken để xác thực" });
                }

                // ✅ Xác thực ID Token với Firebase
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
                if (decodedToken.Uid != request.FirebaseUid)
                {
                    return Unauthorized(new { Message = "Xác thực Firebase thất bại" });
                }

                // ✅ Đăng nhập hoặc tạo người dùng mới
                var (user, jwtToken, refreshToken) = await _authenticationService.AuthenticateWithGoogleAsync(
                    request.FirebaseUid, request.Email, request.Name
                );

                return Ok(new
                {
                    Message = "Login successful",
                    User = new
                    {
                        user.UserId,
                        user.Name,
                        user.Email,
                        user.RoleId,
                        user.FirebaseUid
                    },
                    Token = jwtToken,
                    RefreshToken = refreshToken
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Lỗi Server", Error = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.RefreshToken))
            {
                return BadRequest(new { Message = "Dữ liệu đầu vào không hợp lệ" });
            }

            var newToken = await _tokenService.RefreshTokenAsync(model.RefreshToken);
            if (newToken == null)
            {
                return Unauthorized(new { Message = "Refresh Token không hợp lệ hoặc đã hết hạn" });
            }

            return Ok(new { Message = "Token mới", Token = newToken });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Không xác định được người dùng." });
            }

            var result = await _authenticationService.LogoutAsync(userId);
            if (!result)
            {
                return BadRequest(new { Message = "Đăng xuất thất bại." });
            }

            return Ok(new { Message = "Đăng xuất thành công." });
        }


    }
}
