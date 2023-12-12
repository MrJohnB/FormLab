using LiteBulb.FormLab.Web.Blazor;
using LiteBulb.FormLab.Web.Blazor.ConfigSections;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

var baseAddress = new BaseAddress() { Address = builder.HostEnvironment.BaseAddress };

builder.Services.AddSingleton<BaseAddress>(baseAddress);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
