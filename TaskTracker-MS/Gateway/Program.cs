/*
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Gateway Running");

app.MapGet("/alive", () => "Alive");

app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy"
}));

app.Run();*/

/*
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// ✅ IMPORTANT: map endpoints FIRST
app.MapGet("/health", () => Results.Ok("Healthy"));
app.MapGet("/alive", () => Results.Ok("Alive"));

// ❌ Ocelot LAST (it will take remaining routes only)
//await app.UseOcelot();

app.UseWhen(ctx => ctx.Request.Path != "/health", appBuilder =>
{
    appBuilder.UseOcelot().Wait();
});

app.Run();*/

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

await app.UseOcelot();

// ❌ REMOVE ALL ASP.NET HEALTH ENDPOINTS FROM HERE

app.Run();