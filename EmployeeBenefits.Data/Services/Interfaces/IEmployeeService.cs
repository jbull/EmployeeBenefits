using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate);

        Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate);

        Task<Employee> AddOrUpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int id);
    }
}
