using Microsoft.Extensions.Logging;

namespace Rfid.Core.Rfid;
internal sealed class RfidService(
    ILogger<RfidService> logger) : IRfidService
{
    public Task<Rfid> AddAsync(Rfid rfid)
    {
        logger.LogInformation("Added RFID: {RFID}", rfid.Id);

        return Task.FromResult(rfid);
    }

    public Task<Rfid> GetAsync(Guid id)
    {
        DateTime utcNow = DateTime.UtcNow;
        return Task.FromResult(new Rfid
        {
            Id = id,
            ValidFrom = DateOnly.FromDateTime(utcNow),
            ValidTo = DateOnly.FromDateTime(utcNow.AddDays(14))
        });
    }
}
