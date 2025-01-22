namespace Rfid.Core.Entities;

public sealed class Rfid
{
    public Rfid(Guid? id = null, DateOnly? validFrom = null, DateOnly? validTo = null)
    {
        SetId(id);
        SetValidity(validFrom, validTo);
    }

    private void SetId(Guid? id = null)
    {
        if(id == Guid.Empty)
            throw new ArgumentException($"{nameof(id)} cannot be an empty {nameof(Guid)}.");

        Id = id ?? Guid.NewGuid();
    }

    private void SetValidity(DateOnly? validFrom, DateOnly? validTo)
    {
        if(validFrom is not null && validFrom < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new ArgumentOutOfRangeException(nameof(validFrom), $"{nameof(validTo)} must not be in past.");
        }

        if(validTo is not null && validTo <= validFrom)
        {
            throw new ArgumentOutOfRangeException(nameof(validTo), $"{nameof(validTo)} must be after {nameof(validFrom)}.");
        }

        ValidFrom = validFrom;
        ValidTo = validTo;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateOnly? ValidFrom { get; private set; }
    public DateOnly? ValidTo { get; private set; }
}