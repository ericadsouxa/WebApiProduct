//using Newtonsoft.Json;
using Day1Part1.DAO;
using Day1Part1.Data;
using ProductWebAPI.Api.DAO;
namespace Day1Part1
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

            // Add ProductRepositoryImplementation to service container
            //builder.Services.AddSingleton<IProductRepository, ProductRepositoryImplementation>();
            builder.Services.AddScoped<IProductDao, ProductRepositoryImplementation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}