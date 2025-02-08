using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using Translation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalization();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var host = builder.Build();
var js = host.Services.GetRequiredService<IJSRuntime>();
await SetLanguage(js, "en-US");
await host.RunAsync();

async Task SetLanguage(IJSRuntime jsRuntime, string culture)
{
    var newCulture = new CultureInfo(culture);
    CultureInfo.DefaultThreadCurrentCulture = newCulture;
    CultureInfo.DefaultThreadCurrentUICulture = newCulture;

    //await jsRuntime.InvokeVoidAsync("blazorCulture.set", culture);
}