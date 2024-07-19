using EmployeeFormThroughDotNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});
builder.Services.AddDbContext<EmployeeDBContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=EmployeeDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
