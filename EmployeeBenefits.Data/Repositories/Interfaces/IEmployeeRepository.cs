using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate);

        Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate);

        Task<Employee> AddOrUpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int id);
    }
}
