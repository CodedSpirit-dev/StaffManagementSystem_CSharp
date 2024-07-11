using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StaffTemplate.Client;
using StaffTemplate.Client.Services;
using StaffTemplate.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "http://localhost:5004/")
    });

// Registro del servicio EmployeeService
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

await builder.Build().RunAsync();
