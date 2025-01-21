using Inc.TestSupport;
using Shouldly;

namespace Rfid.Core.Tests.Folder;

public sealed class RfidTests
{
    private readonly TestContext _testContext;

    public RfidTests()
    {
        _testContext = new TestContext();
    }

    [Fact]
    internal void GIVEN_WHEN_RfidConstructed_THEN_RfidIdIsNotEmpty()
    {
        // GIVEN WHEN
        var rfid = _testContext.Create<Entities.Rfid>();

        // THEN
        rfid.ShouldNotBeNull();
        rfid.Id.ShouldNotBe(Guid.Empty);
    }
}