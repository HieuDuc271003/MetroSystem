<<<<<<< HEAD
﻿using MetroSystem.Data.RequestModel.ResponseUserModel;
using System.Collections.Generic;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
>>>>>>> e644d97 (Adjust the Admin Pages)
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IAdminService
    {
<<<<<<< HEAD
        Task<bool> SetUserStatusAsync(string email, bool status);
        Task<List<ResponseUserModel>> GetAllUsersAsync(); 
=======
        Task<bool> SetUserStatusAsync(string userId, bool status);
>>>>>>> e644d97 (Adjust the Admin Pages)
    }
}
