
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot config
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Register Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

app.MapGet("/", () => "Gateway is running successfully 🚀");

await app.UseOcelot();

app.Run();