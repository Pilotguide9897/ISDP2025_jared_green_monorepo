using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Mappings;
using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<BullseyeContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("BullseyeDB"), new MySqlServerVersion(new Version(9, 1, 0))));

// Register services for dependency injection
// builder.Services.AddTransient<ITransaction>();

// Add additional logging providers (console, debug)
builder.Services.AddLogging(builder =>
{
    builder.AddConfiguration(configuration.GetSection(("Logging"))).AddConsole().AddDebug();
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddScoped<IEmployees, EmployeeService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IEncryption, EncryptionService>();
builder.Services.AddScoped<IJsonWebToken, JsonWebTokenService>();
builder.Services.AddScoped<ICustomerOrders, CustomerOrdersService>(); ;
builder.Services.AddScoped<IDeliveries, DeliveriesService>();
builder.Services.AddScoped<ILocations, LocationsService>();
builder.Services.AddScoped<IInventory, InventoryService>();




builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register one mapper
//builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseDefaultFiles();
//app.MapStaticAssets();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
