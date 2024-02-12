using Application;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Infrastructure.UnitOfWork;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Services;
using Application.Interfaces.Repos.Utlities;
using Application.Services.Utilities;
using Application.Interfaces.Services.Utlities;
using Application.Interfaces.Repos.DbConfiguration;
using Infrastructure.Repositories.DbConfiguration;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IChatRepo,ChatRepo>();

builder.Services.AddTransient<IAuthenticator, Authenticator>();
// Unit of Work
builder.Services.AddScoped<IUnitofWork, UnitofWork>();

//Services
builder.Services.AddScoped(typeof(IGenericServices<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserService, UserService>();

builder.Logging.AddRinLogger(); 
builder.Services.AddRin();

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var Config = config.GetSection("Jwt");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Key"]!));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Config["Issuer"],
        ValidAudience = Config["Audience"],
        IssuerSigningKey = key
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

}

);
builder.Services.AddScoped<IDbConfiguration, DbConfiguration>();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseRin();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRinDiagnosticsHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
