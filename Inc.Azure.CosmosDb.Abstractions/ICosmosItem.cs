namespace Inc.Azure.CosmosDb.Abstractions;

public interface ICosmosItem
{
    string Id { get; set; }
    string PartitionKey { get; }
}