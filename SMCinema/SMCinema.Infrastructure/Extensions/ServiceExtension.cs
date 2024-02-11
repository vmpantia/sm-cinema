using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMCinema.Domain.Contracts;
using SMCinema.Infrastructure.Database.Contexts;
using SMCinema.Infrastructure.Database.Repositories;

namespace SMCinema.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddIntrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext or SMCinemaDbContext in services
            services.AddDbContext<SMCinemaDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));

            // Add Repositories in services
            services.AddScoped<IMovieRepository, MovieRepository>()
                    .AddScoped<ICategoryRepository, CategoryRepository>();
        }
            
    }
}
