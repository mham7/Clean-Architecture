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
using Infrastructure.Kafka;
using Application.Services.Background;
using MassTransit;
using ServiceStack;
using Domain.Models;
using MassTransit.KafkaIntegration;

namespace API.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory();
                x.AddRider(rider =>
                {
                    rider.AddConsumer<KafkaConsumer>();
                    rider.UsingKafka((context, k) => { k.Host("pkc-4r087.us-west2.gcp.confluent.cloud:9092"); });
                });
            });

            

            services.AddMassTransit(x =>
            {
                x.UsingInMemory();

                x.AddRider(rider =>
                {
                    rider.AddProducer<Message>("u_chats");

                    rider.UsingKafka((context, k) => { k.Host("pkc-4r087.us-west2.gcp.confluent.cloud:9092"); });
                });
            });


            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
           services.AddScoped<IUserRepo, UserRepo>();
           services.AddScoped<IKafkaProducer, KafkaProducer>();
           services.AddScoped<IChatRepo, ChatRepo>();
           services.AddScoped<IUserChatRepo, UserChatRepo>();
           services.AddScoped<IMessageRepo, MessageRepo>();
           services.AddScoped<IUnitofWork, UnitofWork>();
           services.AddScoped<IDbConfiguration, DbConfiguration>();
           services.AddDbContext<AppDbContext>();
           services.AddHostedService<BackgroundConsumer>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IAuthenticator, Authenticator>();
            services.AddScoped(typeof(IGenericServices<>), typeof(GenericService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUserChatService, UserChatService>();
            services.AddScoped<IHelper, Helpercs>();
            services.AddScoped<IProfilePicService, ProfilePicService>();
            services.AddScoped<IMessagingService, MessagingService>();
            services.AddAutoMapper(typeof(Program), typeof(MappingProfile));
            services.AddTransient<IClaimsService, ClaimsService>();
            services.AddTransient<IMappers, Mappers>();
            return services;
        }

        public static IServiceCollection AddAPI(this IServiceCollection services,IConfiguration config)
        {

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

            services.AddControllers(config =>
            {
                config.Filters.Add(new GlobalExceptionFilter());
                config.Filters.Add(new ValidationFilter());

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
