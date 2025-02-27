using MetroSystem.Data.Enities;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/admin")]
   // [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpPut("Update-User-Status")]
        public async Task<IActionResult> SetUserStatus([FromBody] UpdateUserStatusRequest request)
        {
            var result = await _adminService.SetUserStatusAsync(request.Email, request.Status);
            if (!result)
            {
                return NotFound(new { Message = "User không tồn tại" });
            }

            return Ok(new { Message = "Cập nhật trạng thái thành công" });
        }
    }
}
