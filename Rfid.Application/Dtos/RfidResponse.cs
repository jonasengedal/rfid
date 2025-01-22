namespace Rfid.Application.Dtos;
public record RfidResponse(Guid Id, DateOnly? ValidFrom = null, DateOnly? ValidTo = null)
{
}
