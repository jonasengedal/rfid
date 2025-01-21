namespace Rfid.Infrastructure.Persistence;

internal partial class RfidMapper
{
    public static RfidEntity MapToEntity(Core.Entities.Rfid rfid)
    {
        return new RfidEntity
        {
            Id = rfid.Id.ToString(),
            ValidFrom = rfid.ValidFrom,
            ValidTo = rfid.ValidTo
        };
    }

    public static Core.Entities.Rfid MapToDomain(RfidEntity insertedRfid)
    {
        return new Core.Entities.Rfid
        {
            Id = Guid.Parse(insertedRfid.Id),
            ValidFrom = insertedRfid.ValidFrom,
            ValidTo = insertedRfid.ValidTo
        };
    }
}
