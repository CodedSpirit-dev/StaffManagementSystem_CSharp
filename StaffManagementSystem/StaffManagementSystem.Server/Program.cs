using Microsoft.EntityFrameworkCore;
using StaffTemplate.server.Mappings;
using StaffTemplate.server.Services;
using StaffTemplate.Server.Data;
using StaffTemplate.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Edit CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5000", "http://localhost:5001", "https://localhost:5173", "https://localhost:5085")
        .AllowCredentials());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(EmployeeManagementMapping));

// Register DbContext with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                      opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds))); // Increase command timeout

// Register services
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // Use interface to resolve dependencies

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
