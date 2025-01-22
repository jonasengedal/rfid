namespace Rfid.Application.Dtos;

public record CreateRfidRequest(Guid? Id = null, DateOnly? ValidFrom = null, DateOnly? ValidTo = null)
{
}
