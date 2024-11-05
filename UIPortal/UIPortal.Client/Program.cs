using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BusinessLogicLayer; // Ensure this namespace is added
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register your services here
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
