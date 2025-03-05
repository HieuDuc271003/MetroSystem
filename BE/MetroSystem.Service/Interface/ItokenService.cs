using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Service.Interface
{
    public interface ItokenService
    {
        string GenerateJwtToken(User user);

        string GenerateRefreshToken();

        Task<string> RefreshTokenAsync(string refreshToken);
    }
}
