using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Rfid.Application.Services;

namespace Rfid.Functions.Api.Functions
{
    public class GetRfidHttpTrigger(IRfidService rfidService)
    {
        [Function(nameof(GetRfidHttpTrigger))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "HttpTrigger requires a parameter for the reuuest")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rfid/{id:guid}")] HttpRequest req, Guid id)
        {
            var rfidResponse = await rfidService.GetAsync(id);
            return new OkObjectResult(rfidResponse);
        }
    }
}
