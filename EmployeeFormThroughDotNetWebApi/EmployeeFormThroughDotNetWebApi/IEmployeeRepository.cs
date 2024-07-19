using EmployeeFormThroughDotNetWebApi.Models;

namespace EmployeeFormThroughDotNetWebApi
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeData>> GetAllAsync();
        Task<EmployeeData> GetByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeData employeeData);
        Task UpdateEmployeeAsync(EmployeeData employeeData);
        Task DeleteEmployeeAsync(int id);

    }
}
