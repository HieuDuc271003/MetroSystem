using MetroSystem.Data.Interface;
using MetroSystem.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MetroSystem.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationRepositories, AuthenticationRepositorises>();
            service.AddScoped<IAdminRepositories, AdminRepositories>();
            service.AddScoped<IMetroLineRepository, MetroLineRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
