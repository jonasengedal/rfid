using Inc.Azure.CosmosDb.Abstractions;
using Rfid.Core.Interfaces;

namespace Rfid.Infrastructure.Persistence;
internal class RfidCosmosDbRepository(ICosmosDbRepository<RfidEntity> cosmosDbRepository) : IRfidRepository
{
    public async Task<Core.Entities.Rfid> GetAsync(Guid id)
    {
        var rfidEntity = await cosmosDbRepository.GetAsync(id.ToString()).ConfigureAwait(false);
        return RfidMapper.MapToDomain(rfidEntity);
    }

    public async Task<Core.Entities.Rfid> InsertAsync(Core.Entities.Rfid rfid)
    {
        var insertedRfid = await cosmosDbRepository.InsertAsync(RfidMapper.MapToEntity(rfid)).ConfigureAwait(false);

        return RfidMapper.MapToDomain(insertedRfid);
    }
}
