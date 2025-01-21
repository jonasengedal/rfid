using Rfid.Core.Entities;

namespace Rfid.Core;

internal partial class CoreMapper
{
    public static RfidEntity MapToEntity(Models.Rfid rfid)
    {
        return new RfidEntity
        {
            Id = rfid.Id.ToString(),
            ValidFrom = rfid.ValidFrom,
            ValidTo = rfid.ValidTo
        };
    }

    public static Models.Rfid MapToDomain(RfidEntity insertedRfid)
    {
        return new Models.Rfid
        {
            Id = Guid.Parse(insertedRfid.Id),
            ValidFrom = insertedRfid.ValidFrom,
            ValidTo = insertedRfid.ValidTo
        };
    }
}
