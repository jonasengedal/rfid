using System.Collections.Concurrent;
using Inc.SharedKernel.Interfaces;
using Newtonsoft.Json;
using Rfid.Core.Interfaces;

namespace Rfid.Infrastructure.TestSupport.Fakes;

internal sealed class RfidRepositoryFake : IRfidRepository
{
    private readonly ConcurrentBag<string> storage = [];

    public Task<Core.Entities.Rfid> GetAsync(Guid id)
    {
        var item = storage
            .Select(Deserialize)
            .FirstOrDefault(i => i.Id == id);

        return item != null ?
            Task.FromResult(item) :
            throw new NotFoundException($"RFID {id} was not found.");
    }

    public async Task<Core.Entities.Rfid> InsertAsync(Core.Entities.Rfid item)
    {
        storage.Add(Serialize(item));
        return await GetAsync(item.Id);
    }

    private static string Serialize(Core.Entities.Rfid item)
    {
        return JsonConvert.SerializeObject(item);
    }

    private static Core.Entities.Rfid Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<Core.Entities.Rfid>(json) ??
            throw new InvalidOperationException($"Cannot parse json to {nameof(Core.Entities.Rfid)}.");
    }
}