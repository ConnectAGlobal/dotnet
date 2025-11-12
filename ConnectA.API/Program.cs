using ConnectA.API.Extensions;
using ConnectA.Application.Configurations;
using ConnectA.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ConnectA.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configs = builder.Configuration.Get<Settings>();

        builder.Services.AddInfrastructure(configs); 
        builder.Services.AddHealthServices(configs.ConnectionStrings);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger(configs.Swagger);
        builder.Services.AddVersioning();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.MapHealthChecks("/api/health-check", new HealthCheckOptions()
        {
            ResponseWriter = HealthCheckExtensions.WriteResponse
        });

        app.Run();
    }
}