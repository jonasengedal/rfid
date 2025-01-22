using Inc.TestSupport;
using Rfid.Infrastructure.Persistence;

namespace Rfid.Infrastructure.Tests;

internal class RfidInfrastructureTestContext : TestContext
{
    public RfidInfrastructureTestContext() : base()
    {
        Fixture.Customize<RfidEntity>(c => c
            .With(r => r.Id, Create<Guid>().ToString())
            .With(r => r.ValidFrom, DateOnly.FromDateTime(DateTime.UtcNow))
            .With(r => r.ValidTo, DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1))));
    }
}