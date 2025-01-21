using Rfid.Core.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Rfid.Infrastructure.TestSupport.Fakes;

public static class FakeServiceCollectionExtensions
{
    public static IServiceCollection AddFakeCosmosDbRepository(this IServiceCollection services)
    {
        services.AddFake(typeof(ICosmosDbRepository<>), typeof(CosmosDbRepositoryFake<>));
        return services;
    }

    internal static IServiceCollection AddFake(this IServiceCollection services, Type interfaceType, Type fakeType)
    {
        var repositories =
            services.Where(i => i.ServiceType == interfaceType)
            .ToList();

        repositories.ForEach(r => services.Remove(r));

        services.AddSingleton(interfaceType, fakeType);
        return services;
    }
}