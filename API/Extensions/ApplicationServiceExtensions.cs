using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
    IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt => // Tells the app to use your DataContext (custom EF Core DB class).​
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection")); //Reads connection string from appsettings.json
        });
        services.AddCors(); //Adds Cross-Origin Resource Sharing support so your Angular frontend (localhost:4200) can talk to the backend (localhost:5001).
        services.AddScoped<ITokenService, TokenService>();
        //You have an interface ITokenService and a class TokenService that implements it. You are telling .net that
        //Whenever someone asks for ITokenService, give them an instance of TokenService.

        return services;//Returns the modified services back to the pipeline.

    }

}
