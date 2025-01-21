using Rfid.Core.Entities;
using Shouldly;

namespace Rfid.Core.Tests;

public sealed class CoreMapperTests
{
    private readonly TestContext testContext;
    public CoreMapperTests()
    {
        testContext = new TestContext();
    }

    [Fact]
    internal void GIVEN_Rfid_WHEN_MapToEntity_THEN_RfidEntityIsReturned()
    {
        // GIVEN
        var rfid = testContext.Create<Models.Rfid>();

        // WHEN
        var rfidEntity = CoreMapper.MapToEntity(rfid);

        // THEN
        rfidEntity.Id.ShouldBe(rfid.Id.ToString());
        rfidEntity.ValidFrom.ShouldBe(rfid.ValidFrom);
        rfidEntity.ValidTo.ShouldBe(rfid.ValidTo);
    }

    [Fact]
    internal void GIVEN_RfidEntity_WHEN_MapToDomain_THEN_RfidIsReturned()
    {
        // GIVEN
        var rfidEntity = testContext.Create<RfidEntity>();

        // WHEN
        var rfid = CoreMapper.MapToDomain(rfidEntity);

        // THEN
        rfid.Id.ToString().ShouldBe(rfidEntity.Id);
        rfid.ValidFrom.ShouldBe(rfidEntity.ValidFrom);
        rfid.ValidTo.ShouldBe(rfidEntity.ValidTo);
    }

    // TODO: test unhappy paths
}

