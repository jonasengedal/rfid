using Inc.Azure.CosmosDb.Abstractions;
using Inc.SharedKernel.Exceptions;
using Microsoft.Azure.Cosmos;
using Rfid.Core.Interfaces;

namespace Rfid.Infrastructure.Persistence;
internal class RfidCosmosDbRepository(ICosmosDbRepository<RfidEntity> cosmosDbRepository) : IRfidRepository
{
    public async Task<Core.Entities.Rfid> GetAsync(Guid id)
    {
        try
        {
            var rfidEntity = await cosmosDbRepository.GetAsync(id.ToString()).ConfigureAwait(false);
            return RfidMapper.MapToDomain(rfidEntity);
        }
        catch (CosmosException e)
        {
            if(e.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException($"RFID {id} is not found.");
            
            throw new InternalException("Could not get RFID.", e);
        }
    }

    public async Task<Core.Entities.Rfid> InsertAsync(Core.Entities.Rfid rfid)
    {
        var insertedRfid = await cosmosDbRepository.InsertAsync(RfidMapper.MapToEntity(rfid)).ConfigureAwait(false);

        return RfidMapper.MapToDomain(insertedRfid);
    }
}
