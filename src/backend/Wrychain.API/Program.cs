using Wrychain.DAL;
using Wrychain.DAL.Repository;
using Wrychain.Service;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var MSSQLConnection = builder.Configuration.GetConnectionString("MSSQLConnection");
var RedisConnection = builder.Configuration.GetConnectionString("RedisConnection");

// Session
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = RedisConnection;
    options.InstanceName = "Wrychain_";
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(MSSQLConnection));
// Repositories
builder.Services.AddScoped<PlatformInviteRepository>();
builder.Services.AddScoped<StationRepository>();
builder.Services.AddScoped<UserRepository>();
// Services
builder.Services.AddScoped<PlatformInviteService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles();
app.UseSession();
app.MapControllers();
app.Run();
