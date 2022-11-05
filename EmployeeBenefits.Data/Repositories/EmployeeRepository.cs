using System.Linq.Expressions;
using AutoMapper;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
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

            return employees; // _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _db.Employees.SingleOrDefaultAsync(x => x.Id == id);

            return employee; // _mapper.Map<EmployeeDto>(employee);
      
        }

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate)
        {
            var employee = await _db.Employees.FindAsync(predicate);

            return employee; // _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<Employee>> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            var employees = await _db.Employees.ToListAsync();

            return employees; // _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<Employee> AddOrUpdateEmployee(Employee employee)
        {
            //var employee = _mapper.Map<EmployeeDto, Employee>(employee);

            if(employee.Id > 0)
            {
                _db.Employees.Update(employee);
            }
            else
            {
                _db.Employees.Add(employee);
            }

            await _db.SaveChangesAsync();

            return employee; // _mapper.Map<EmployeeDto>(employee);
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
    }
}
