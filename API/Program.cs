using API.Data;
using API.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<MusicContext>(opt => 
            opt.UseSqlite(builder.Configuration.GetConnectionString("APIDb")));
        
        builder.Services.AddTransient<IMusicRepository, MusicRepository>();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        
        //TimeSpan is not described properly on OpenAPI document
        //https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2505
        builder.Services.AddSwaggerGen(options =>
        {
            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
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


        app.MapControllers();

        app.Run();
    }
}
