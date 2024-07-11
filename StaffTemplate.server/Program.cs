using Microsoft.EntityFrameworkCore;
using StaffTemplate.server.Data;
using StaffTemplate.server.Mappings;
using StaffTemplate.server.Services;
using StaffTemplate.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Register AutoMapper
    services.AddAutoMapper(typeof(EmployeeManagementMapping));

    // Register DbContext with connection string
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                          opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds))); // Increase command timeout

    // Register services
    services.AddScoped < IEmployeeService, EmployeeService>(); // Use interface to resolve dependencies
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        // Enable Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
    }

    //Enable CORS for all origins
    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

    // Enable authorization middleware
    app.UseAuthorization();

    // Map controllers
    app.MapControllers();
}
