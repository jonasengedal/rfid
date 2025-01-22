using Rfid.Application.Dtos;

namespace Rfid.Application;
internal class RfidDtoMapper
{
    public static Core.Entities.Rfid MapToDomain(CreateRfidRequest createRfidRequest)
        => new(createRfidRequest.Id, createRfidRequest.ValidFrom, createRfidRequest.ValidTo);

    public static RfidResponse MapToDto(Core.Entities.Rfid rfid)
        => new(rfid.Id, rfid.ValidFrom, rfid.ValidTo);
}
