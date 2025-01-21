using Microsoft.Extensions.DependencyInjection;

namespace Rfid.Application.Services;

public static class RfidServiceCollectionExtensions
{
    public static IServiceCollection AddRfid(this IServiceCollection services)
    {
        services.AddTransient<IRfidService, RfidService>();
        return services;
    }
}
