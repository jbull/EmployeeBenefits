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
        Task<IEnumerable<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int id);

        Task<EmployeeDto> GetEmployee(Expression<Func<Employee, bool>> predicate);

        IEnumerable<EmployeeDto> FindEmployees(Expression<Func<Employee, bool>> predicate);

        Task<EmployeeDto> AddOrUpdateEmployee(Employee entity);

        Task<bool> DeleteEmployee(int id);
    }
}
