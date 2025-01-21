using Newtonsoft.Json;

namespace Inc.Azure.CosmosDb.Abstractions;

public abstract class BaseEntity : IEntity
{
    [JsonProperty("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    string IEntity.PartitionKey => GetPartitionKey();

    protected virtual string GetPartitionKey() => Id;
}
