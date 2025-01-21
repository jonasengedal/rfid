namespace Rfid.Core.Interfaces;
public interface IRfidRepository
{
    Task<Entities.Rfid> GetAsync(Guid id);
    Task<Entities.Rfid> InsertAsync(Entities.Rfid rfidEntity);
}
