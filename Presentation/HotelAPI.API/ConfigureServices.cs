//using HotelAPI.Application.Identity;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;

//namespace HotelAPI.API;

//public static class ConfigureServices
//{
//    public static void AddSwaggerSetting(this IServiceCollection services)
//    {
//        services.AddSwaggerGen(c =>
//        {
//            c.SwaggerDoc("v1", new OpenApiInfo
//            {
//                Title = "Hotel Management System",
//                Version = "v1",
//                Description = "Hotel Management System sistemində istifadə olunan API-lər "

//            });
//            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//            {
//                Name = "Authorization",
//                Type = SecuritySchemeType.ApiKey,
//                Scheme = "Bearer",
//                BearerFormat = "JWT",
//                In = ParameterLocation.Header,
//                Description = "JWT Authorization header using the Bearer scheme.",
//            });

//            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//            {
//                {  new OpenApiSecurityScheme
//                   {
//                    Reference = new OpenApiReference
//                    {
//                        Type = ReferenceType.SecurityScheme,
//                        Id = "Bearer"
//                    },
//                    Scheme = "Bearer",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                },
//                 new List<string>()
//                }
//            });

           
//        });
//    }
//    public static void AuthenticationJwtSettings(this IServiceCollection services, IJWTOptions jwtSettings)
//    {
//        services.AddAuthentication(options =>
//        {
//            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//        })
//             .AddJwtBearer(options =>
//             {
//                 options.RequireHttpsMetadata = false;
//                 options.TokenValidationParameters = new TokenValidationParameters
//                 {
//                     ValidIssuer = jwtSettings.Issuer,
//                     ValidAudience = jwtSettings.Audience,
//                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
//                     ClockSkew = TimeSpan.Zero
//                 };

//             });
//    }

//}
