using System.ComponentModel.DataAnnotations;
using Inc.TestSupport;
using Shouldly;

namespace Rfid.Core.Tests.Entities;

public sealed class RfidTests
{
    private readonly TestContext _testContext;

    public RfidTests()
    {
        _testContext = new TestContext();
    }

    [Fact]
    internal void Given_NoParams_When_RfidConstructed_THEN_OnlyIdIsSet()
    {
        // GIVEN WHEN
        var rfid = new Core.Entities.Rfid();

        // THEN
        rfid.ShouldSatisfyAllConditions(
            () => rfid.Id.ShouldNotBe(Guid.Empty),
            () => rfid.ValidFrom.ShouldBeNull(),
            () => rfid.ValidTo.ShouldBeNull());
    }

    [Fact]
    internal void GIVEN_AllParams_WHEN_RfidConstructed_THEN_AllPropsAreSet()
    {
        // GIVEN
        var id = _testContext.Create<Guid>();
        var utcNow = DateTime.UtcNow;
        var validFrom = DateOnly.FromDateTime(utcNow);
        var validTo = DateOnly.FromDateTime(utcNow.AddDays(1));
        
        // WHEN
        var rfid = new Core.Entities.Rfid(id, validFrom, validTo);

        // THEN
        rfid.ShouldSatisfyAllConditions(
            () => rfid.Id.ShouldBe(id),
            () => rfid.ValidFrom.ShouldBe(validFrom),
            () => rfid.ValidTo.ShouldBe(validTo)
            );
    }

    [Fact]
    internal void GIVEN_EmptyId_WHEN_RfidConstructed_THEN_ArgumentExceptionThrow()
    {
        // GIVEN WHEN
        Should.Throw<ArgumentException>(() => new Core.Entities.Rfid(Guid.Empty));
    }

    [Fact]
    internal void GIVEN_ValidToIsInPast_WHEN_RfidConstructed_THEN_ValidToIsSetToCurrentDate()
    {
        // GIVEN
        var validFrom = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));

        // THEN
        Should.Throw<ArgumentOutOfRangeException>(() => new Core.Entities.Rfid(Guid.NewGuid(), validFrom));
    }

    [Fact]
    internal void GIVEN_ValidToBeforeValidFrom_When_RfidConstructed_THEN_ArgumentExceptionThrown()
    {
        // GIVEN
        var validFrom = DateOnly.FromDateTime(DateTime.UtcNow);
        var validTo = validFrom.AddDays(-1);

        // WHEN
        Should.Throw<ArgumentOutOfRangeException>(() => new Core.Entities.Rfid(Guid.NewGuid(), validFrom, validTo));
    }
}