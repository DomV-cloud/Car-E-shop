using Car_E_shop.Authorization;
using Car_E_shop.Database.Context;
using Car_E_shop.Models;
using Car_E_shop.RepositoryPattern.Interfaces;
using Car_E_shop.RepositoryPattern.UserRepo;
using Car_E_shop.Services.ChechForNull;
using Car_E_shop.Services.ValidateId;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Car_E_shop
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddAuthentication("ApiKey")
                .AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", opts => opts.ApiKey = builder.Configuration.GetValue<string>("AllowedApiKeys"));

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddTransient<IValidateIdService, ValidateIdService>();
            builder.Services.AddTransient<ICheckNull, CheckForNullService>();
            builder.Services.AddTransient<IRepository<User>, UserRepository>();

            
            builder.Services.AddDbContext<EshopContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
            builder.Services.AddMemoryCache();

            builder.Services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseApiKeyMiddleware();

            app.MapControllers();

            app.Run();
        }


     
    }
}