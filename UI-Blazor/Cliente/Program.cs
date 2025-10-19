using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cliente;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ensure the BaseAddress has a trailing slash to avoid path concatenation issues
var baseAddr = builder.HostEnvironment.BaseAddress;
if (!baseAddr.EndsWith('/')) baseAddr += '/';
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddr) });

await builder.Build().RunAsync();
