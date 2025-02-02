using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Rfid.Infrastructure.Persistence;
using Rfid.Application.Services;
using Inc.Azure.CosmosDb;

var builder = FunctionsApplication.CreateBuilder(args);
builder.Services
    .AddRfid()
    .AddCosmosDbRepository()
    .AddRfidCosmosDbRepository();
builder.ConfigureFunctionsWebApplication();

// TODO: Add Exception middleware

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
