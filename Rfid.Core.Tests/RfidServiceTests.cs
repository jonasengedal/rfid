using Shouldly;

namespace Rfid.Core.Tests;

public sealed class RfidServiceTests
{
    private readonly TestContext _testContext;
    private readonly IRfidService rfidService;


    public RfidServiceTests()
    {
        _testContext = new TestContext(services =>
            services
                .AddRfid()
            );

        rfidService = _testContext.Resolve<IRfidService>();
    }

    [Fact]
    internal async Task GIVEN_ValidRfid_WHEN_AddAsync_THEN_RfidIsSaved()
    {
        // GIVEN
        var inputRfid = _testContext.Create<Rfid>();

        // WHEN
        var addedRfid = await rfidService.AddAsync(inputRfid);

        // THEN
        addedRfid.ShouldNotBeNull();
        addedRfid.ShouldBe(inputRfid);
    }

    [Fact]
    internal async Task GIVEN_Id_WHEN_GetASync_THEN_RfidIsReturned()
    {
        // GIVEN
        var id = Guid.NewGuid();

        // WHEN
        var rfid = await rfidService.GetAsync(id);

        // THEN
        rfid.ShouldNotBeNull();
        rfid.Id.ShouldBe(id);
    }

    // TOOD: Test unhappy paths
}

