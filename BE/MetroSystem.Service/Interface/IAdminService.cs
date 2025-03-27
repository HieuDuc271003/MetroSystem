using MetroSystem.Data.RequestModel.ResponseUserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface IAdminService
    {
        Task<bool> SetUserStatusAsync(string email, bool status);
        Task<List<ResponseUserModel>> GetAllUsersAsync(); 
        Task<ResponseUserModel> CreateStaffAsync(RequestCreateStaff request);

    }
}
