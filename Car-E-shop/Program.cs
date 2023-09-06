using Car_E_shop.Database.Context;
using Car_E_shop.Services.ValidateId;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

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

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddSingleton<IValidateIdService, ValidateIdService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


     
    }
}