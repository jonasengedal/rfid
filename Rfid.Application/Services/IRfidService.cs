using Rfid.Application.Dtos;

namespace Rfid.Application.Services;

public interface IRfidService
{
    Task<RfidResponse> AddAsync(CreateRfidRequest rfid);
    Task<RfidResponse> GetAsync(Guid id);
}