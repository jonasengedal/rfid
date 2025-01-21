using Rfid.Core.Common;
using Rfid.Core.Entities;
using Rfid.Core.Services;
using Rfid.Infrastructure.TestSupport.Fakes;
using Shouldly;

namespace Rfid.Core.Tests;

public sealed class RfidServiceTests
{
    private readonly TestContext _testContext;
    private readonly IRfidService rfidService;
    private readonly ICosmosDbRepository<RfidEntity> repository;


    public RfidServiceTests()
    {
        _testContext = new TestContext(services => 
            services
                .AddRfid()
                .AddFakeCosmosDbRepository()
            );

        rfidService = _testContext.Resolve<IRfidService>();
        repository = _testContext.Resolve<ICosmosDbRepository<RfidEntity>>();
    }

    [Fact]
    internal async Task GIVEN_ValidRfid_WHEN_AddAsync_THEN_RfidIsSaved()
    {
        // GIVEN
        var inputRfid = _testContext.Create<Models.Rfid>();

        // WHEN
        var addedRfid = await rfidService.AddAsync(inputRfid);

        // THEN
        addedRfid.ShouldNotBeNull();
        addedRfid.ShouldNotBe(inputRfid);

        var persistedRfid = await repository.GetAsync(addedRfid.Id.ToString());
        persistedRfid.ShouldNotBeNull();
        persistedRfid.Id.ShouldBe(inputRfid.Id.ToString());
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

    private async Task<Models.Rfid> AddRfidAsync(Models.Rfid? rfid = null)
    {
        return await rfidService.AddAsync(rfid ?? _testContext.Create<Models.Rfid>());
    }
}