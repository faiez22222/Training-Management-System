using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskApi.Exceptions;
using TaskApi.Models;
using TaskApi.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using log4net;
using System.Reflection;
using log4net.Config;

namespace TaskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var jwtSetting = builder.Configuration.GetSection("Jwt");
            var secretKey = jwtSetting["Key"];
            var issuser = jwtSetting["Issuser"];

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                   option =>
                   {
                       option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = issuser,
                           ValidAudience = issuser,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                       };
                   }
                );

            // Add Required Dependencies here
            builder.Services.AddDbContext<TaskContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=TaskDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));
            builder.Services.AddScoped<ITaskRepository.ITask, ITaskRepository.TaskRepository>();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var app = builder.Build();
            if(app.Environment.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseMiddleware<ExceptionHandlingMiddleware>();
            }

            // Configure the HTTP request pipeline.
           // app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}