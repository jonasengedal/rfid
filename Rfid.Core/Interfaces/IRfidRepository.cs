namespace Rfid.Core.Interfaces;
// This could instead be a generic repository like the one from Ardalis.Specification but e.g. placed in Inc.Persistence.Abstractions
// https://github.com/ardalis/Specification/blob/main/Specification/src/Ardalis.Specification/IRepositoryBase.cs
public interface IRfidRepository
{
    Task<Entities.Rfid> GetAsync(Guid id);
    Task<Entities.Rfid> InsertAsync(Entities.Rfid rfidEntity);
}
