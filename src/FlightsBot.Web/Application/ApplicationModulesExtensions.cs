using FlightsBot.Infrustructure.Implementation.DataAccess;

namespace FlightsBot.Web.Application;

public static class ApplicationModulesExtensions
{
    public static IServiceCollection ConfigureApplicationModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);

        return services;
    }
}
