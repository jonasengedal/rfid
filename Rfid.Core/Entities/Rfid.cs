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
        ValidFrom = validFrom ?? DateOnly.FromDateTime(DateTime.UtcNow);
        
        if(validTo is not null && validTo <= ValidFrom)
        {
            throw new ArgumentOutOfRangeException($"{nameof(validTo)} must be after {nameof(validFrom)}.");
        }

        ValidTo = validTo;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateOnly? ValidFrom { get; private set; }
    public DateOnly? ValidTo { get; private set; }
}