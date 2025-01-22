using System.Collections.Concurrent;
using System.Net;
using Inc.Azure.CosmosDb.Abstractions;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace Inc.Azure.CosmosDb.TestSupport.Fakes;

internal sealed class CosmosDbRepositoryFake<TItem> : ICosmosDbRepository<TItem> where TItem : ICosmosItem
{
    private readonly ConcurrentBag<string> storage = [];

    public Task<TItem> GetAsync(string id, string? partitionKey = null)
    {
        var item = storage
            .Select(Deserialize)
            .FirstOrDefault(
                        i => i.Id == id
                        && new PartitionKey(partitionKey ?? id) == new PartitionKey(i.PartitionKey));

        return item != null ?
            Task.FromResult(item) :
            throw new CosmosException(string.Empty, HttpStatusCode.NotFound, 0, string.Empty, 0);
    }

    public async Task<TItem> InsertAsync(TItem item)
    {
        storage.Add(CosmosDbRepositoryFake<TItem>.Serialize(item));
        return await GetAsync(item.Id, item.PartitionKey);
    }

    private static string Serialize(TItem item)
    {
        return JsonConvert.SerializeObject(item);
    }

    private static TItem Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<TItem>(json) ??
            throw new InvalidOperationException($"Cannot parse json to {typeof(TItem)}.");
    }
}