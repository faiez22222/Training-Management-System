using EmployeeFormThroughDotNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFormThroughDotNetWebApi
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<EmployeeData>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeData> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync
    }
}
