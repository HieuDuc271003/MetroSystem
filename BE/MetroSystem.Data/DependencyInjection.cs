using MetroSystem.Data.Interface;
using MetroSystem.Data.Repositories;
using MetroSystem.Service.Interface;
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
            service.AddScoped<IBusLineRepository, BusLineRepository>();
            service.AddScoped<IBusScheduleRepository, BusScheduleRepository>();
            service.AddScoped<IBusStationRepository, BusStationRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IMetroStationRepository, MetroStationRepository>();
            service.AddScoped<IFeedbackRepository, FeedbackRepository>();
            service.AddScoped<IBookmarkRepository, BookmarkRepository>();   
            service.AddScoped<IScheduleRepository, ScheduleRepository>();
            return service;
        }
    }
}
