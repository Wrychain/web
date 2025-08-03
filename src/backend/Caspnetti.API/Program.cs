using Caspnetti.DAL;
using Caspnetti.DAL.Repository;
using Caspnetti.Service;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var MSSQLConnection = builder.Configuration.GetConnectionString("MSSQLConnection");

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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
