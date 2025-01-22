using Newtonsoft.Json;

namespace Inc.Azure.CosmosDb.Abstractions;

public abstract class BaseCosmosItem : ICosmosItem
{
    [JsonProperty("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    string ICosmosItem.PartitionKey => GetPartitionKey();

    protected virtual string GetPartitionKey() => Id;
}
