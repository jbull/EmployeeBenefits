using System.Linq.Expressions;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddOrUpdateEmployee(EmployeeDto entity);

        Task<bool> DeleteEmployee(int id);

        Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate);

        Task<Employee> GetSingleOrDefault(Expression<Func<Employee, bool>> predicate);

        Task<Employee> GetEmployeeBy(int id);

        Task<List<Employee>> GetAllEmployees();
    }
}
