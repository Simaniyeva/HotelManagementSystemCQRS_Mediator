using FluentValidation.AspNetCore;
using System.Reflection;

namespace HotelAPI.Infrastructure.Utilities.Extentions;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddControllers().AddFluentValidation(opt =>
        {
            opt.ImplicitlyValidateChildProperties = true;
            opt.ImplicitlyValidateRootCollectionElements = true;
            opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.Scan(scan => scan.FromAssemblies(
               typeof(IApplicationAssemblyMarker).Assembly).AddClasses(@class =>
               @class.Where(type =>
               !type.Name.StartsWith('I')
               && type.Name.EndsWith("Service")))
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsImplementedInterfaces()
               .WithScopedLifetime());
        return services;
        //}
    }
}
