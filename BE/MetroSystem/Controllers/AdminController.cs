//using MetroSystem.Data.Enities;
//using MetroSystem.Service.Interface;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace MetroSystem.Controllers
//{
//    [ApiController]
//    [Route("api/admin")]
//    [Authorize(Roles = "Admin")]
//    public class AdminController : Controller
//    {
//        private readonly IAdminService _adminService;

//        public AdminController(IAdminService adminService)
//        {
//            _adminService = adminService;
//        }


//        [HttpPut("Update-User-Status")]
//        public async Task<IActionResult> SetUserStatus([FromBody] UpdateUserStatusRequest request)
//        {
//            var result = await _adminService.SetUserStatusAsync(request.Email, request.Status);
//            if (!result)
//            {
//                return NotFound(new { Message = "User không tồn tại" });
//            }

//            return Ok(new { Message = "Cập nhật trạng thái thành công" });
//        }


//    }
//}

using MetroSystem.Data.Enities;
using MetroSystem.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MetroSystem.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut("Update-User-Status")]
        [Authorize(Roles = "R2")]
        public async Task<IActionResult> SetUserStatus([FromBody] UpdateUserStatusRequest request)
        {
            var result = await _adminService.SetUserStatusAsync(request.Email, request.Status);
            if (!result)
            {
                return NotFound(new { Message = "User không tồn tại" });
            }

            return Ok(new { Message = "Cập nhật trạng thái thành công" });
        }

        // API lấy danh sách tất cả người dùng (Chỉ Admin mới truy cập được)
        [HttpGet("get-all-users")]
        [Authorize(Roles = "R2")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
