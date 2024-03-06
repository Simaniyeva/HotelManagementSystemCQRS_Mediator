using HotelAPI.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelAPI.Persistence.Utilities.Extentions;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelIdentityDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        return services;
    }
}
