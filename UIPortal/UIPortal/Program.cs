using UIPortal.Client.Pages;
using UIPortal.Components;

using BusinessLogicLayer; // Add this namespace
using DataAccessLayer; // If needed
using DataAccessLayer.Interfaces;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
//added this
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddTransient<ICustomerService, CustomerService>(); // Ensure the implementation is correct
//builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped(sp => new HttpClient 
                { BaseAddress =
                    new Uri(builder.Configuration["CustomerAppAPI:BaseUrl"]) });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UIPortal.Client._Imports).Assembly);

app.Run();
