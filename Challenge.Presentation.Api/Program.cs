using Microsoft.EntityFrameworkCore;
using Challenge.Infra.Data.Context;
using Challenge.Presentation.Api.Extensions;

namespace Challenge.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureDependencyInjection();
            builder.Services.AddDbContext<ChallengeContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            //Removido para o desafio
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //Removido para o desafio
            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}