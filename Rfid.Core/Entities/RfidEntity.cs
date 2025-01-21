using Rfid.Core.Common;

namespace Rfid.Core.Entities;

internal sealed class RfidEntity : BaseEntity
{
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}
