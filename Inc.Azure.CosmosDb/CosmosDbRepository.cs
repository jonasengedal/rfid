using Inc.Azure.CosmosDb.Abstractions;
using Microsoft.Azure.Cosmos;

namespace Rfid.Infrastructure.Persistence.CosmosDb;

internal sealed class CosmosDbRepository<TItem>(CosmosDbContainerProvider containerProvider) : ICosmosDbRepository<TItem>
    where TItem : ICosmosItem
{
    public async Task<TItem> GetAsync(string id, string? partitionKey = null)
    {
        ArgumentNullException.ThrowIfNull(id);

        // TODO: Catch CosmosException and throw Core.NotFoundException, Core.InternalErrorException
        var container = await containerProvider.GetContainer().ConfigureAwait(false);
        return await container.ReadItemAsync<TItem>(id, new PartitionKey(partitionKey ?? id)).ConfigureAwait(false);
    }

    public async Task<TItem> InsertAsync(TItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var container = await containerProvider.GetContainer().ConfigureAwait(false);
        return await container.CreateItemAsync(item).ConfigureAwait(false);
    }
}
