using Inc.TestSupport;
using Rfid.Infrastructure.Persistence;
using Shouldly;

namespace Rfid.Infrastructure.Tests;

public sealed class RfidMapperTests
{
    private readonly TestContext testContext;
    public RfidMapperTests()
    {
        testContext = new RfidInfrastructureTestContext();
    }

    [Fact]
    internal void GIVEN_Rfid_WHEN_MapToEntity_THEN_RfidEntityIsReturned()
    {
        // GIVEN
        var rfid = testContext.Create<Core.Entities.Rfid>();

        // WHEN
        var rfidEntity = RfidMapper.MapToEntity(rfid);

        // THEN
        rfidEntity.ShouldSatisfyAllConditions(
            () => rfidEntity.Id.ShouldBe(rfid.Id.ToString()),
            () => rfidEntity.ValidFrom.ShouldBe(rfid.ValidFrom),
            () => rfidEntity.ValidTo.ShouldBe(rfid.ValidTo));
    }

    [Fact]
    internal void GIVEN_RfidEntity_WHEN_MapToDomain_THEN_RfidIsReturned()
    {
        // GIVEN
        var rfidEntity = testContext.Create<RfidEntity>();

        // WHEN
        var rfid = RfidMapper.MapToDomain(rfidEntity);

        // THEN
        rfid.ShouldSatisfyAllConditions(
            () => rfid.Id.ToString().ShouldBe(rfidEntity.Id),
            () => rfid.ValidFrom.ShouldBe(rfidEntity.ValidFrom),
            () => rfid.ValidTo.ShouldBe(rfidEntity.ValidTo));
    }

    // TODO: test unhappy paths
}
