using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Cliente;
using Cliente.Services;
using Cliente.Auth;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ensure the BaseAddress has a trailing slash to avoid path concatenation issues
var baseAddr = builder.HostEnvironment.BaseAddress;
if (!baseAddr.EndsWith('/')) baseAddr += '/';

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5108") });
builder.Services.AddScoped<HotelService>();

await builder.Build().RunAsync();
