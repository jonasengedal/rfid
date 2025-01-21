using Inc.Azure.CosmosDb.Abstractions;

namespace Rfid.Infrastructure.Persistence;

internal sealed class RfidEntity : BaseEntity
{
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}
