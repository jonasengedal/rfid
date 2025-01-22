namespace Rfid.Infrastructure.Persistence;

internal partial class RfidMapper
{
    public static RfidCosmosItem MapToEntity(Core.Entities.Rfid rfid)
    {
        return new RfidCosmosItem
        {
            Id = rfid.Id.ToString(),
            ValidFrom = rfid.ValidFrom,
            ValidTo = rfid.ValidTo
        };
    }

    public static Core.Entities.Rfid MapToDomain(RfidCosmosItem insertedRfid)
    {
        return new Core.Entities.Rfid
        (
            Guid.Parse(insertedRfid.Id),
            insertedRfid.ValidFrom,
            insertedRfid.ValidTo
        );
    }
}
