namespace Rfid.Application.Services;

public interface IRfidService
{
    Task<Core.Entities.Rfid> AddAsync(Core.Entities.Rfid rfid);
    Task<Core.Entities.Rfid> GetAsync(Guid id);
}