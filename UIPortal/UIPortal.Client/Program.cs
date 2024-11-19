using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using UIPortal.Client.Pages;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register your services here

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

////







/////





await builder.Build().RunAsync();
