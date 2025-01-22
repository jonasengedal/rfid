using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using Rfid.Application.Dtos;
using Rfid.Application.Services;

namespace Rfid.Functions.Api.Functions;

public class AddRfidHttpTrigger(IRfidService rfidService)
{
    [Function(nameof(AddRfidHttpTrigger))]
    public async Task<IActionResult> Run(
         [HttpTrigger(AuthorizationLevel.Function, "post", Route = "rfid")] HttpRequest request)
    {
        var createRfidRequest = await BodyToItem<CreateRfidRequest>(request);

        var rfidResponse = await rfidService.AddAsync(createRfidRequest).ConfigureAwait(false);

        return new OkObjectResult(rfidResponse);
    }

    // TODO: Get built in deserialization to work
    private static async Task<T> BodyToItem<T>(HttpRequest request)
    {
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);

        var item = JsonConvert.DeserializeObject<T>(requestBody)
         ?? throw new ArgumentException("Payload could not be deserialized");
        return item;
    }
}
