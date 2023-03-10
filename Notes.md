1. In bullet 2, it states `Startup` class.
   1. In ASP.NET Core 6 application for `web` template, there's no `Startup.cs`. Do it in `Program.cs` instead.
2. The nested class of `SnapshotCollectorTelemetryProcessorFactory` doesn't work very well inside top level statement in `Program.cs`, it is clearer to pull it out to a standalone class.
