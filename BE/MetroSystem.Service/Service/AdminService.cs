<<<<<<< HEAD
﻿//using MetroSystem.Data.Interface;
//using MetroSystem.Service.Interface;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MetroSystem.Service.Service
//{
//    public class AdminService : IAdminService
//    {
//        private readonly IAdminRepositories _adminRepositories;
//        private readonly IConfiguration _configuration;
//        private readonly IUnitOfWork _unitOfWork;

//        public AdminService(IAdminRepositories adminRepositories, IConfiguration configuration, IUnitOfWork unitOfWork)
//        {
//            _adminRepositories = adminRepositories;
//            _configuration = configuration;
//            _unitOfWork = unitOfWork;
//        }


//        public async Task<bool> SetUserStatusAsync(string email, bool status)
//        {
//            var user = await _unitOfWork.Admin.GetEmailIdAsync(email);
//            if (user == null)
//            {
//                return false; // User không tồn tại
//            }

//            await _unitOfWork.Admin.UpdateStatusAsync(email, status);
//            await _unitOfWork.SaveChangesAsync(); // Lưu thay đổi vào DB

//            return true;
//        }
//    }
//}

using MetroSystem.Data.Interface;
using MetroSystem.Data.RequestModel.ResponseUserModel;
using MetroSystem.Service.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
=======
﻿using MetroSystem.Data.Interface;
using MetroSystem.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
>>>>>>> e644d97 (Adjust the Admin Pages)
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepositories _adminRepositories;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IAdminRepositories adminRepositories, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _adminRepositories = adminRepositories;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

<<<<<<< HEAD
=======

>>>>>>> e644d97 (Adjust the Admin Pages)
        public async Task<bool> SetUserStatusAsync(string email, bool status)
        {
            var user = await _unitOfWork.Admin.GetEmailIdAsync(email);
            if (user == null)
            {
<<<<<<< HEAD
                return false;
            }

            await _unitOfWork.Admin.UpdateStatusAsync(email, status);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // Thêm phương thức lấy danh sách user
        public async Task<List<ResponseUserModel>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Admin.GetAllUsersAsync();
            return users.Select(u => new ResponseUserModel
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Status = u.Status,
                RoleId = u.RoleId,
                FirebaseUid = u.FirebaseUid,
                RefreshToken = u.RefreshToken,
                RefreshTokenExpiry = u.RefreshTokenExpiry
            }).ToList();
        }
    }
}

=======
                return false; // User không tồn tại
            }

            await _unitOfWork.Admin.UpdateStatusAsync(email, status);
            await _unitOfWork.SaveChangesAsync(); // Lưu thay đổi vào DB

            return true;
        }
    }
}
>>>>>>> e644d97 (Adjust the Admin Pages)
