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
            service.AddScoped<IMetroLineService, MetroLineService>();
            service.AddScoped<IBusLineService, BusLineService>();
            service.AddScoped<ItokenService, TokenService>();
            service.AddScoped<IFeedbackService, FeedbackService>();
            service.AddScoped<IMetroStationService, MetroStationService>();
            service.AddScoped<IBookmarkService, BookmarkService>();
            service.AddScoped<IScheduleService, ScheduleService>();
            service.AddHttpClient<IGeocodingService, GeocodingService>();
            return service;
        }
    }
}
