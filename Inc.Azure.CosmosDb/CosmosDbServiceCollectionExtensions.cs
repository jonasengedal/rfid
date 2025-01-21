using Inc.Azure.CosmosDb.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Rfid.Infrastructure.Persistence.CosmosDb;

namespace Inc.Azure.CosmosDb;

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
