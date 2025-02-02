﻿using Microsoft.Extensions.DependencyInjection;
using Rfid.Core.Interfaces;

namespace Rfid.Infrastructure.TestSupport.Fakes;

public static class FakeServiceCollectionExtensions
{
    public static IServiceCollection AddFakeRfidRepository(this IServiceCollection services)
    {
        services.AddFake(typeof(IRfidRepository), typeof(RfidRepositoryFake));
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