using MetroSystem.Data.Interface;
using MetroSystem.Data.Repositories;
using MetroSystem.Service.Interface;
using MetroSystem.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MetroSystem.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IAdminService, AdminService>();
            return service;
        }
    }
}
