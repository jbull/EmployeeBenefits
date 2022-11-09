using EmployeeBenefits.Data.Models;
using System.Linq.Expressions;

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

        Task<IEnumerable<Dependent>> GetDependents(int id);

        Task<Dependent> AddOrUpdateDependent(Dependent dependent);

        Task<bool> DeleteDependent(int id);
    }
}
