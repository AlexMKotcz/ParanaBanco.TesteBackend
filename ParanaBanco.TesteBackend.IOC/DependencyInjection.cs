using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ParanaBanco.TesteBackend.Application.Interfaces;
using ParanaBanco.TesteBackend.Application.Services;
using ParanaBanco.TesteBackend.Data;
using ParanaBanco.TesteBackend.Data.Repository;
using ParanaBanco.TesteBackend.Domain.Interfaces;

namespace ParanaBanco.TesteBackend.IOC;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();

        services.AddSingleton<IRepositoryProcesser, RepositoryProcesser>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DatabaseConnection"
        ), b => b.MigrationsAssembly(typeof(DataDbContext).Assembly.FullName)));

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}