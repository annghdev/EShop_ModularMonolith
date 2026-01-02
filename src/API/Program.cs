using API;
using Catalog;
using Kernel.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

//builder.Services.AddInfrasDB(builder.Configuration);
builder.Services.AddCatalogContainer(builder.Configuration);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return Results.Ok("Server is running...");
});

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints(typeof(Catalog.DependencyInjection).Assembly);

app.Run();
