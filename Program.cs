using CoolZoneAPI.Infraestructure.Context;
using CoolZoneAPI.Persistence.Repositories; // Adicione este using
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
// using CoolZoneAPI.Domain.Entity; // Geralmente não é necessário aqui para o registro genérico, mas pode ser útil se for referenciado em outro lugar no Program.cs

namespace CoolZoneAPI
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
            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"],
                    Description = "API para controle de abrigos contta calor extremo",
                    Contact = new OpenApiContact { Name = "Felipe Santana, Emily Macedo, Gabriela Gomes Cezar", Email = "RM558916@fiap.com.br" }
                });
            });

            // Adicione a linha abaixo para registrar o seu repositório genérico!
            // Isso resolverá a dependência para IRepository<City> e IRepository<ThermalShelter>
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
