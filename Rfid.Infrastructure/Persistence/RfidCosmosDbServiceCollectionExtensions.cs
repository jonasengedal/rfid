using Microsoft.Extensions.DependencyInjection;
using Rfid.Core.Interfaces;

namespace Rfid.Infrastructure.Persistence;

public static class RfidCosmosDbServiceCollectionExtensions
{
    public static IServiceCollection AddRfidCosmosDbRepository(this IServiceCollection services)
    {

        services
            .AddTransient(typeof(IRfidRepository), typeof(RfidCosmosDbRepository));
        return services;
    }
}
