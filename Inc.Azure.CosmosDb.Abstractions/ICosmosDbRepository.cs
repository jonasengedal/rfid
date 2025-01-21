namespace Inc.Azure.CosmosDb.Abstractions;

// Could have used https://github.com/IEvangelist/azure-cosmos-dotnet-repository instead
// but wanted to show use of TestSupport project with Fake implementation of ICosmosRepository
public interface ICosmosDbRepository<TItem> where TItem : IEntity
{
    /// <summary>
    /// Get an item of type <typeparamref name="TItem"/> from Cosmos.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="partitionKey"></param>
    /// <returns>The item with the given key.</returns>
    Task<TItem> GetAsync(string id, string? partitionKey = null);
    /// <summary>
    /// Insert an item of type <typeparamref name="TItem"/> into Cosmos.
    /// </summary>
    /// <param name="item">The item to insert</param>
    /// <returns>The inserted item.</returns>
    Task<TItem> InsertAsync(TItem item);
}
