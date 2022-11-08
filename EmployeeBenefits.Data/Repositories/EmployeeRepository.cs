using System.Linq.Expressions;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefits.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> employees = await _db.Employees.ToListAsync();

            return employees;

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _db.Employees.SingleOrDefaultAsync(x => x.Id == id);

            return employee; 
      
        }

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate)
        {
            var employee = await _db.Employees.FindAsync(predicate);

            return employee; 
        }

        public async Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            var employees = await _db.Employees.ToListAsync();

            return employees; 
        }

        public async Task<Employee> AddOrUpdateEmployee(Employee employee)
        {
            if(employee.Id > 0)
            {
                _db.Employees.Update(employee);
            }
            else
            {
                _db.Employees.Add(employee);
            }

            await _db.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                {
                    return false;
                }

                _db.Employees.Remove(employee);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Dependent>> GetDependents(int id)
        {
            IEnumerable<Dependent> dependents = await _db.Dependents.Where(x=> x.EmployeeId == id).ToListAsync();

            return dependents;
        }

        public async Task<Dependent> AddOrUpdateDependent(Dependent dependent)
        {
            if (dependent.Id > 0)
            {
                _db.Dependents.Update(dependent);
            }
            else
            {
                _db.Dependents.Add(dependent);
            }

            await _db.SaveChangesAsync();

            return dependent;
        }

        public async Task<bool> DeleteDependent(int id)
        {
            try
            {
                var dependent = await _db.Dependents.FirstOrDefaultAsync(x => x.Id == id);
                if (dependent == null)
                {
                    return false;
                }

                _db.Dependents.Remove(dependent);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
