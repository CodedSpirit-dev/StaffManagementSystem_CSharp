using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StaffTemplate.server.Data;
using StaffTemplate.server.Mappings;
using StaffTemplate.server.Repository;
using StaffTemplate.server.Repository.IRepository;

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
    services.AddAutoMapper(typeof(EmployeeManagementMapping));

    // Register DbContext with connection string
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                          opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds))); // Increase command timeout

    services.AddScoped<EmployeeService>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseAuthorization();

    app.MapControllers();
}
