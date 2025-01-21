using Microsoft.Azure.Cosmos;

namespace Rfid.Infrastructure.Persistence.CosmosDb;

public class CosmosDbContainerProvider
{
    internal async Task<Container> GetContainer()
    {
        // TODO: Do not hard code read from IConfiguration or IOptions
        CosmosClient client = new(
            accountEndpoint: "https://localhost:8081/",
            authKeyOrResourceToken: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
        );

        Database database = await client.CreateDatabaseIfNotExistsAsync(
            id: "engedal",
            throughput: 400
        );

        Container container = await database.CreateContainerIfNotExistsAsync(
            id: "rfids",
            partitionKeyPath: "/id"
        );

        return container;
    }
}