using CoolZoneAPI.Infraestructure.Context;
using CoolZoneAPI.Persistence.Repositories; 
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CoolZoneAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                   {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"],
                    Description = "API para controle de abrigos contta calor extremo",
                    Contact = new OpenApiContact { Name = "Felipe Santana, Emily Macedo, Gabriela Gomes Cezar", Email = "RM558916@fiap.com.br" }
                });
            });

            builder.Services.AddAutoMapper(typeof(Program));

            
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IThermalShelterRepository, ThermalShelterRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            var app = builder.Build();

            


            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
