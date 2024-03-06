using HotelAPI.API;
using HotelAPI.Application.Helpers;
using HotelAPI.Application.Identity.Concrete;
using HotelAPI.Domain.Entities.Identity;
using HotelAPI.Infrastructure.Utilities.Extentions;
using HotelAPI.Persistence.DbContexts;
using HotelAPI.Persistence.Utilities.Extentions;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true; // Optional, to suppress client error mapping
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); ;

builder.Services.AddEndpointsApiExplorer();


builder.Services.Configure<FileServerPath>(builder.Configuration.GetSection("FileServerPath"));
FileServerPath filePath = builder.Configuration.GetSection("FileServerPath").Get<FileServerPath>();

builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWTOptions"));
JWTOptions jwtSettings = builder.Configuration.GetSection("JWTOptions").Get<JWTOptions>();
builder.Services.AddApplicationServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration(builder.Configuration);
//builder.Services.AuthenticationJwtSettings(jwtSettings);
builder.Services.AddSwaggerGen
    (c => c.SchemaFilter<EnumSchemaFilter>());

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<HotelIdentityDbContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
