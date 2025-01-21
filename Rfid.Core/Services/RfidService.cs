using Microsoft.Extensions.Logging;
using Rfid.Core.Common;
using Rfid.Core.Entities;

namespace Rfid.Core.Services;
internal sealed class RfidService(
    ICosmosDbRepository<RfidEntity> repository,
    ILogger<RfidService> logger) : IRfidService
{
    public async Task<Models.Rfid> AddAsync(Models.Rfid rfid)
    {
        var insertedRfid = await repository.InsertAsync(CoreMapper.MapToEntity(rfid)).ConfigureAwait(false);

        logger.LogInformation("Added RFID: {RFID}", insertedRfid.Id);

        return CoreMapper.MapToDomain(insertedRfid);
    }

    public async Task<Models.Rfid> GetAsync(Guid id)
    {
        var rfidEntity = await repository.GetAsync(id.ToString());
        return CoreMapper.MapToDomain(rfidEntity);
    }
}