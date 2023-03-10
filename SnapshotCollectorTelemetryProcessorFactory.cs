using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.SnapshotCollector;
using Microsoft.Extensions.Options;

internal class SnapshotCollectorTelemetryProcessorFactory : ITelemetryProcessorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SnapshotCollectorTelemetryProcessorFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public ITelemetryProcessor Create(ITelemetryProcessor next)
    {
        IOptions<SnapshotCollectorConfiguration> snapshotConfigurationOptions = _serviceProvider.GetRequiredService<IOptions<SnapshotCollectorConfiguration>>();
        return new SnapshotCollectorTelemetryProcessor(next, configuration: snapshotConfigurationOptions.Value);
    }
}