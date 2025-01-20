using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using Rfid.Core.Rfid;

namespace Rfid.Functions.Api.Command;

public class AddRfidHttpTrigger(IRfidService rfidService)
{
   [Function(nameof(AddRfidHttpTrigger))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "rfid")] HttpRequest request)
    {
        var rfid = await BodyToItem<Core.Rfid.Rfid>(request);

        rfid = await rfidService.AddAsync(rfid);

        return new OkObjectResult(rfid);
    }

    // TODO: Get built in deserialization to work
    private static async Task<T> BodyToItem<T>(HttpRequest request)
    {
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();

        var item = JsonConvert.DeserializeObject<T>(requestBody)
         ?? throw new ArgumentException("Payload could not be deserialized");
        return item;
    }
}
