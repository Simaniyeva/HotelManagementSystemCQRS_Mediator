
namespace HotelAPI.Infrastructure.Utilities.Extentions;

public static class ConfigureServices
{
    public static  IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(scan => scan.FromAssemblies(
               typeof(IInfrastructureAssemblyMarker).Assembly).AddClasses(@class =>
               @class.Where(type =>
               !type.Name.StartsWith('I')
               && type.Name.EndsWith("Repository")))
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsImplementedInterfaces()
               .WithScopedLifetime());
        return services;
    }
}
