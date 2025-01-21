namespace Inc.Azure.CosmosDb.Abstractions;

public interface IEntity
{
    string Id { get; set; }
    string PartitionKey { get; }
}