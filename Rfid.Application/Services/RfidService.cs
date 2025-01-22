using Microsoft.Extensions.Logging;
using Rfid.Application.Dtos;
using Rfid.Core.Interfaces;

namespace Rfid.Application.Services;
internal sealed class RfidService(
    IRfidRepository repository,
    ILogger<RfidService> logger) : IRfidService
{
    public async Task<RfidResponse> AddAsync(CreateRfidRequest createRfidRequest)
    {
        var rfid = RfidDtoMapper.MapToDomain(createRfidRequest);
        var insertedRfid = await repository.InsertAsync(rfid).ConfigureAwait(false);

        logger.LogInformation("Added RFID: {RFID}", insertedRfid.Id);

        return RfidDtoMapper.MapToDto(insertedRfid);
    }

    public async Task<RfidResponse> GetAsync(Guid id)
    {
        var rfid = await repository.GetAsync(id).ConfigureAwait(false);
        return RfidDtoMapper.MapToDto(rfid);
    }
}