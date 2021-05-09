using Application.Features.Leaderboards.Interfaces;
using Application.Features.Races.Interfaces;
using Application.Features.Vehicles.Interfaces;
using Infrastructure.Features.Leaderboards;
using Infrastructure.Features.Races;
using Infrastructure.Features.Vehicles;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("DakarRallyDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ILeaderboardsRepository, LeaderboardsRepository>();

            return services;
        }
    }
}
