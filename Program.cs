using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.ApplicationInsights.SnapshotCollector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddSnapshotCollector(config => builder.Configuration.Bind(nameof(SnapshotCollectorConfiguration), config));
builder.Services.AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp));

var app = builder.Build();

app.MapGet("/", () =>
{
    throw new InvalidOperationException("Ooops");
});

app.Run();
