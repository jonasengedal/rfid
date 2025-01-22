using Inc.Azure.CosmosDb.Abstractions;

namespace Rfid.Infrastructure.Persistence;

internal sealed class RfidCosmosItem : BaseCosmosItem
{
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}
