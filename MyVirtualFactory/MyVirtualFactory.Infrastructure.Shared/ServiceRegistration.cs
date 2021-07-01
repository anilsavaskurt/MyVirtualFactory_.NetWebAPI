using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyVirtualFactory.Application.Interfaces;
using MyVirtualFactory.Domain.Settings;
using MyVirtualFactory.Infrastructure.Shared.Services;

namespace MyVirtualFactory.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
