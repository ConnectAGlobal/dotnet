using ConnectA.API.Extensions;
using ConnectA.Application;
using ConnectA.Application.Configurations;
using ConnectA.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ConnectA.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configs = builder.Configuration.Get<Settings>();
        
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        builder.Services.AddInfrastructure(configs); 
        builder.Services.AddHealthServices(configs.ConnectionStrings);
        builder.Services.AddUseCases();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger(configs.Swagger);
        builder.Services.AddVersioning();
        builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
        builder.Services.AddFluentValidationAutoValidation();

        var app = builder.Build();

        app.UseErrorHandling();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
                {
                    ui.SwaggerEndpoint("/swagger/v1/swagger.json",  "MottuGrid.API v1");
                    ui.SwaggerEndpoint("/swagger/v2/swagger.json",  "MottuGrid.API v2");
                }
            );
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