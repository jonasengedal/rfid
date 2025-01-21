namespace Rfid.Core.Entities;

public sealed class Rfid
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateOnly? ValidFrom { get; init; }
    public DateOnly? ValidTo { get; init; }
}