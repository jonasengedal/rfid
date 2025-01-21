namespace Rfid.Core;

public interface IRfidService
{
    Task<Rfid> AddAsync(Rfid rfid);
    Task<Rfid> GetAsync(Guid id);
}