using Figura.SpeedwayNetwork.Model;
using Figura.SpeedwayNetwork.Service;

namespace Figura.SpeedwayNetwork.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection IncludeNetworkDb(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration
                .GetSection("ConnectionStrings")
                .GetSection("Figura.Network")
                .Get<string>()!;

            return services.AddTransient<SpeedwayNetworkDb>(x => new SpeedwayNetworkDb(connectionString));
        }

        public static IServiceCollection IncludeNetworkService(this IServiceCollection services)
        {
            return services.AddTransient<INetworkService, NetworkService>();
        }
    }
}
