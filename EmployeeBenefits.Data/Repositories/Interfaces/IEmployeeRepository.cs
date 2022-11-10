using EmployeeBenefits.Data.Models;
using System.Linq.Expressions;

namespace EmployeeBenefits.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> AddOrUpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int id);
    }
}
