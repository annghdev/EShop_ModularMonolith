var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.API>("api")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(api)
    .WaitFor(api);

builder.AddProject<Projects.API>("api");

builder.Build().Run();
