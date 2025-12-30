var builder = DistributedApplication.CreateBuilder(args);

var pgUsername = builder.AddParameter("username", secret: true);
var pgPassword = builder.AddParameter("password", secret: true);

var elasticSearch = builder.AddElasticsearch("elasticsearch");

var postgres = builder.AddPostgres("postgres-eshop", pgUsername, pgPassword)
        //.WithDataVolume(isReadOnly: false)
        .WithPgWeb(pgAdmin => pgAdmin.WithHostPort(5050));

var productDb = postgres.AddDatabase("productdb");

var api = builder.AddProject<Projects.API>("api")
    .WithHttpHealthCheck("/health")
    .WithReference(productDb)
        .WaitFor(productDb)
    .WithReference(elasticSearch)
        .WaitFor(elasticSearch);

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(api)
    .WaitFor(api);

builder.AddProject<Projects.API>("api");

builder.Build().Run();
