using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Rfid.Functions.Api.Query
{
    public class GetRfidHttpTrigger(ILogger<GetRfidHttpTrigger> logger)
    {
        [Function(nameof(GetRfidHttpTrigger))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rfid")] HttpRequest req)
        {
            logger.LogInformation("Get Rfid.");
            DateTime utcNow = DateTime.UtcNow;
            return new OkObjectResult(value: new Core.Rfid.Rfid
            {
                ValidFrom = DateOnly.FromDateTime(utcNow),
                ValidTo = DateOnly.FromDateTime(utcNow.AddDays(14))
            });
        }
    }
}
