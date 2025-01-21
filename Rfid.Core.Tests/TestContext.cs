﻿using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Rfid.Core.Entities;

namespace Rfid.Core.Tests;

internal class TestContext
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Fixture _fixture;

    public TestContext(Action<IServiceCollection>? servicesAction = null)
    {
        var servicesCollection = new ServiceCollection()
           .AddLogging();

        servicesAction?.Invoke(servicesCollection);

        _serviceProvider = servicesCollection.BuildServiceProvider();

        _fixture = new Fixture();
        _fixture.Register(() => DateOnly.FromDateTime(_fixture.Create<DateTime>()));
        _fixture.Customize<RfidEntity>(c => c.With(r => r.Id, _fixture.Create<Guid>().ToString()));
    }

    public T Resolve<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }

    internal T Create<T>()
    {
        return _fixture.Create<T>();
    }
}