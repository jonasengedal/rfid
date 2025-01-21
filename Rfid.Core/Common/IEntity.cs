namespace Rfid.Core.Common;

public interface IEntity
{
    string Id { get; set; }
    string PartitionKey { get; }
}