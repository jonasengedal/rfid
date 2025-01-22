using Inc.TestSupport;
using Rfid.Application.Services;
using Rfid.Core.Interfaces;
using Rfid.Infrastructure.TestSupport.Fakes;
using Shouldly;

namespace Rfid.Application.Tests;

public sealed class RfidServiceTests
{
    private readonly TestContext _testContext;
    private readonly IRfidService rfidService;
    private readonly IRfidRepository repository;


    public RfidServiceTests()
    {
        _testContext = new TestContext(services =>
            services
                .AddRfid()
                .AddFakeRfidRepository()
            );

        rfidService = _testContext.Resolve<IRfidService>();
        repository = _testContext.Resolve<IRfidRepository>();
    }

    [Fact]
    internal async Task GIVEN_ValidRfid_WHEN_AddAsync_THEN_RfidIsSaved()
    {
        // GIVEN
        var inputRfid = new Core.Entities.Rfid();

        // WHEN
        var addedRfid = await rfidService.AddAsync(inputRfid);

        // THEN
        addedRfid.ShouldNotBeNull();
        addedRfid.ShouldNotBe(inputRfid);

        var persistedRfid = await repository.GetAsync(addedRfid.Id);
        persistedRfid.ShouldNotBeNull();
        persistedRfid!.Id.ShouldBe(inputRfid.Id);
    }

    [Fact]
    internal async Task GIVEN_RfidIdOfExistingRfid_WHEN_GetASync_THEN_RfidIsReturned()
    {
        // GIVEN
        var existingRfid = await AddRfidAsync();

        // WHEN
        var rfid = await rfidService.GetAsync(existingRfid.Id);

        // THEN
        rfid.ShouldNotBeNull();
        rfid.ShouldBeEquivalentTo(existingRfid);
    }

    // TOOD: Test unhappy paths

    private async Task<Core.Entities.Rfid> AddRfidAsync(Core.Entities.Rfid? rfid = null)
    {
        return await rfidService.AddAsync(rfid ?? new Core.Entities.Rfid());
    }
}