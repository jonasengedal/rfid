using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Rfid.Core.Services;
using Rfid.Infrastructure.Persistence.CosmosDb;

var builder = FunctionsApplication.CreateBuilder(args);
builder.Services.AddRfid();
builder.Services.AddCosmosDbRepository();
builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
