using Inc.Azure.CosmosDb.Abstractions;
using Inc.Azure.CosmosDb.TestSupport.Fakes;
using Inc.TestSupport;
using Rfid.Core.Interfaces;
using Rfid.Infrastructure.Persistence;
using Shouldly;

namespace Rfid.Infrastructure.Tests;

public sealed class RfidRepositoryTests
{
    private readonly TestContext _testContext;
    private readonly IRfidRepository rfidRepository;
    private readonly ICosmosDbRepository<RfidEntity> repository;


    public RfidRepositoryTests()
    {
        _testContext = new TestContext(services =>
            services
                .AddRfidCosmosDbRepository()
                .AddFakeCosmosDbRepository()
            );

        rfidRepository = _testContext.Resolve<IRfidRepository>();
        repository = _testContext.Resolve<ICosmosDbRepository<RfidEntity>>();
    }

    [Fact]
    internal async Task GIVEN_ValidRfid_WHEN_AddAsync_THEN_RfidIsSaved()
    {
        // GIVEN
        var inputRfid = _testContext.Create<Core.Entities.Rfid>();

        // WHEN
        var addedRfid = await rfidRepository.InsertAsync(inputRfid);

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
        var rfid = await rfidRepository.GetAsync(existingRfid.Id);

        // THEN
        rfid.ShouldNotBeNull();
        rfid.ShouldBeEquivalentTo(existingRfid);
    }

    // TOOD: Test unhappy paths

    private async Task<Core.Entities.Rfid> AddRfidAsync(Core.Entities.Rfid? rfid = null)
    {
        return await rfidRepository.InsertAsync(rfid ?? new Core.Entities.Rfid());
    }
}