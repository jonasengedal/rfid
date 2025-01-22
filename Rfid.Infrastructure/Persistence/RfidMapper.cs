namespace Rfid.Infrastructure.Persistence;

internal partial class RfidMapper
{
    public static RfidCosmosItem MapToEntity(Core.Entities.Rfid rfid) 
        => new()
        {
            Id = rfid.Id.ToString(),
            ValidFrom = rfid.ValidFrom,
            ValidTo = rfid.ValidTo
        };

    public static Core.Entities.Rfid MapToDomain(RfidCosmosItem insertedRfid)
        => new(
            Guid.Parse(insertedRfid.Id),
            insertedRfid.ValidFrom,
            insertedRfid.ValidTo
        );
}
