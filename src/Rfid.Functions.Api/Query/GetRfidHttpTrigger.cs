using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Rfid.Core.Rfid;

namespace Rfid.Functions.Api.Query
{
    public class GetRfidHttpTrigger(IRfidService rfidService)
    {
        [Function(nameof(GetRfidHttpTrigger))]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rfid/{id:guid}")] HttpRequest req, Guid id)
        {
            var rfid = await rfidService.GetAsync(id);
            return new OkObjectResult(rfid);
        }
    }
}
