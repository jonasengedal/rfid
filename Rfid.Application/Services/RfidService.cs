using Microsoft.Extensions.Logging;
using Rfid.Core.Interfaces;

namespace Rfid.Application.Services;
internal sealed class RfidService(
    IRfidRepository repository,
    ILogger<RfidService> logger) : IRfidService
{
    public async Task<Core.Entities.Rfid> AddAsync(Core.Entities.Rfid rfid)
    {
        var insertedRfid = await repository.InsertAsync(rfid).ConfigureAwait(false);

        logger.LogInformation("Added RFID: {RFID}", insertedRfid.Id);

        return insertedRfid;
    }

    public async Task<Core.Entities.Rfid> GetAsync(Guid id)
    {
        var rfid = await repository.GetAsync(id).ConfigureAwait(false);
        return rfid;
    }
}