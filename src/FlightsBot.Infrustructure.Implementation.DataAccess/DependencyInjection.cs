using System;
using FlightsBot.Infrustructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace FlightsBot.Infrustructure.Implementation.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.UseNodaTime();

        NpgsqlDataSource dataSource;
        dataSource = dataSourceBuilder.Build();

        services.AddDbContext<IDbContext, AppDbContext>(
            (_, options) => 
            {
                options
                    .UseNpgsql(dataSource, optionsBuilder => optionsBuilder.UseNodaTime());
            }
        );

        return services;
    }
}
