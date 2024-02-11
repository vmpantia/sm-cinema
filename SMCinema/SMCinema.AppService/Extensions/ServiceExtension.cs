using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SMCinema.AppService.Extensions
{
    public static class ServiceExtension
    {
        public static void AddAppService(this IServiceCollection services) =>
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
