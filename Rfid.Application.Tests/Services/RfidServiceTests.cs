using Inc.TestSupport;
using Rfid.Application.Dtos;
using Rfid.Application.Services;
using Rfid.Core.Interfaces;
using Rfid.Infrastructure.TestSupport.Fakes;
using Shouldly;

namespace Rfid.Application.Tests.Services;

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
        var inputRfid = new CreateRfidRequest();

        // WHEN
        var addedRfid = await rfidService.AddAsync(inputRfid);

        // THEN
        addedRfid.ShouldNotBeNull();

        var persistedRfid = await repository.GetAsync(addedRfid.Id);
        persistedRfid.ShouldNotBeNull();
        persistedRfid.Id.ShouldNotBe(Guid.Empty);
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

    private async Task<RfidResponse> AddRfidAsync(CreateRfidRequest? rfid = null)
    {
        return await rfidService.AddAsync(rfid ?? new CreateRfidRequest());
    }
}