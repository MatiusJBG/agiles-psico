using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Cliente;
using Cliente.Services;
using Cliente.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ensure the BaseAddress has a trailing slash to avoid path concatenation issues
var baseAddr = builder.HostEnvironment.BaseAddress;
if (!baseAddr.EndsWith('/')) baseAddr += '/';
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddr) });

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
