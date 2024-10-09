using lab1.app.Data;
using lab1.app.Interfaces;
using lab1.app.Services;
using Microsoft.EntityFrameworkCore;

namespace lab1.app.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<CinemaDbContext>(opt =>
                opt.UseSqlServer(connectionString));
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ICinemaService, CinemaService>();
        }
    }
}
