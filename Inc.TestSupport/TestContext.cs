using AutoFixture;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.TestSupport;

public class TestContext
{
    private readonly IServiceProvider _serviceProvider;
    
    protected Fixture Fixture { get; }

    public TestContext(Action<IServiceCollection>? servicesAction = null)
    {
        var servicesCollection = new ServiceCollection()
           .AddLogging();

        servicesAction?.Invoke(servicesCollection);

        _serviceProvider = servicesCollection.BuildServiceProvider();

        Fixture = new Fixture();
        Fixture.Register(() => DateOnly.FromDateTime(Fixture.Create<DateTime>()));
    }

    public T Resolve<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }

    public T Create<T>()
    {
        return Fixture.Create<T>();
    }
}