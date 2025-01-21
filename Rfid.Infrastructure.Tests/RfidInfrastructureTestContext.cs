using Inc.TestSupport;
using Rfid.Infrastructure.Persistence;

namespace Rfid.Infrastructure.Tests;

internal class RfidInfrastructureTestContext : TestContext
{
    public RfidInfrastructureTestContext() : base()
    {
        Fixture.Customize<RfidEntity>(c => c.With(r => r.Id, Create<Guid>().ToString()));
    }
}