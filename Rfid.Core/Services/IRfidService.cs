namespace Rfid.Core.Services;

public interface IRfidService
{
    Task<Models.Rfid> AddAsync(Models.Rfid rfid);
    Task<Models.Rfid> GetAsync(Guid id);
}