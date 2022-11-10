using System.Linq.Expressions;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services.Interfaces;

namespace EmployeeBenefits.Data.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate)
        {
            return await _employeeRepository.GetEmployee(predicate);
        }

        public async Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            return await _employeeRepository.FindEmployees(predicate);
        }

        public async Task<Employee> AddOrUpdateEmployee(Employee employee)
        {
            return await _employeeRepository.AddOrUpdateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
