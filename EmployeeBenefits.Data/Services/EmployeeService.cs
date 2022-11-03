using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using EmployeeBenefits.Data.Services.Interfaces;

namespace EmployeeBenefits.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<EmployeeDto> AddOrUpdateEmployee(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetSingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
