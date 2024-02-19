using API.Filters;
using AutoMapper;
using Application.Interfaces.Repos;
using Application.Interfaces.Repos.DbConfiguration;
using Application.Interfaces.Repos.Utlities;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Utlities;
using Application.Interfaces.UnitOfWork;
using Application.Services;
using Application.Services.Utilities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.DbConfiguration;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace API.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
           services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
           services.AddScoped<IUserRepo, UserRepo>();
           services.AddScoped<IChatRepo, ChatRepo>();
           services.AddScoped<IUserChatRepo, UserChatRepo>();
           services.AddScoped<IMessageRepo, MessageRepo>();
           services.AddScoped<IUnitofWork, UnitofWork>();
           services.AddScoped<IDbConfiguration, DbConfiguration>();
           services.AddDbContext<AppDbContext>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IAuthenticator, Authenticator>();
            services.AddScoped(typeof(IGenericServices<>), typeof(GenericService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IHelper, Helpercs>();
            services.AddScoped<IProfilePicService, ProfilePicService>();
            services.AddScoped<IMessagingService, MessagingService>();
            services.AddAutoMapper(typeof(Program), typeof(MappingProfile));
            services.AddTransient<IMappers, Mappers>();
            return services;
        }

        public static IServiceCollection AddAPI(this IServiceCollection services,IConfiguration config)
        {
            
            services.AddScoped<ExceptionFilter>();
            services.AddScoped<ValidationFilter>();
            config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var Config = config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Key"]!));
            services.AddAuthentication(options =>
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

            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ValidationFilter>();

            }

);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
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
            return services;

        }
    }
}
