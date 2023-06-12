using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ParanaBanco.TesteBackend.IOC;

public static class DependencyInjectionSwagger
{
    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteBackend.API", Version = "v1" });
        });
        return services;
    }
}
