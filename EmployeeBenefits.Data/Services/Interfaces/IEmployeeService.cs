using System.Linq.Expressions;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Add(Employee entity);

        void AddRange(IEnumerable<Employee> entities);

        void Update(Employee entity);

        void UpdateRange(IEnumerable<Employee> entities);

        void Remove(int id);

        int Count();

        IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate);

        Task<Employee> GetSingleOrDefault(Expression<Func<Employee, bool>> predicate);

        Task<Employee> GetAsync(int id);

        Task<List<Employee>> GetAllAsync();
    }
}
