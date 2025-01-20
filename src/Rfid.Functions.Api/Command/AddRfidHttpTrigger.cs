using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Rfid.Functions.Api.Command;

public class AddRfidHttpTrigger(ILogger<AddRfidHttpTrigger> logger)
{
   [Function(nameof(AddRfidHttpTrigger))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "rfid")] HttpRequest request)
    {
        var rfid = await BodyToItem<Core.Rfid.Rfid>(request);

        logger.LogInformation("Add Rfid {RFID}", rfid.Id);

        return new OkObjectResult(rfid);
    }

    private static async Task<T> BodyToItem<T>(HttpRequest request)
    {
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();

        var item = JsonConvert.DeserializeObject<T>(requestBody)
         ?? throw new ArgumentException("Payload could not be deserialized");
        return item;
    }
}
