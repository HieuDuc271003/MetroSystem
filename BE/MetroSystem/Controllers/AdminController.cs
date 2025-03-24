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

        //[HttpPut("Update-User-Status")]
        [HttpPut("users/{email}/status")]
        [Authorize(Roles = "R4")]
        public async Task<IActionResult> SetUserStatus([FromBody] UpdateUserStatusRequest request)
        {
            var result = await _adminService.SetUserStatusAsync(request.Email, request.Status);
            if (!result)
            {
                return NotFound(new { Message = "User không tồn tại" });
            }

            return Ok(new { Message = "Cập nhật trạng thái thành công" });
        }

        [HttpGet("users")]
        [Authorize(Roles = "R4")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
