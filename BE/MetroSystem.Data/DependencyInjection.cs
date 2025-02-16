using Microsoft.Extensions.DependencyInjection;

namespace MetroSystem.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            return service;
        }
    }
}
