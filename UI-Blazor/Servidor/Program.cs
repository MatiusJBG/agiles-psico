using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// If the Blazor WebAssembly client is located at ../Cliente/wwwroot relative to the server project,
// set the server WebRootPath so the built-in static file middleware serves client files.
var clientWwwroot = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "Cliente", "wwwroot"));
if (Directory.Exists(clientWwwroot))
{
    builder.Environment.WebRootPath = clientWwwroot;
}
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Serve default files and static files from the WebRootPath (which may have been set to the client wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

// Fallback to index.html to support client-side routing when index.html exists
var indexFilePath = Path.Combine(builder.Environment.WebRootPath ?? builder.Environment.ContentRootPath, "index.html");
if (File.Exists(indexFilePath))
{
    app.MapFallback(async context =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(indexFilePath);
    });
}

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
