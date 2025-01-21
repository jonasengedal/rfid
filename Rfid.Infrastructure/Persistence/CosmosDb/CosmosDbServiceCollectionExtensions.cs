using Microsoft.Extensions.DependencyInjection;
using Rfid.Core.Common;

namespace Rfid.Infrastructure.Persistence.CosmosDb;

public static class CosmosDbServiceCollectionExtensions
{
    public static IServiceCollection AddCosmosDbRepository(this IServiceCollection services)
    {

        services
            .AddSingleton<CosmosDbContainerProvider>()
            .AddSingleton(typeof(ICosmosDbRepository<>), typeof(CosmosDbRepository<>));
        return services;
    }
}
