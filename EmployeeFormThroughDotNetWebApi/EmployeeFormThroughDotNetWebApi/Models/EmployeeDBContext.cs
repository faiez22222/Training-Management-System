using Microsoft.EntityFrameworkCore;
namespace EmployeeFormThroughDotNetWebApi.Models
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options) 
        {

        }  
        public DbSet<EmployeeData> Employees { get; set; }
    }
}
