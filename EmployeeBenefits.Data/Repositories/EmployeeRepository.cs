using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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

        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            IEnumerable<Employee> employees = await _db.Employees.ToListAsync();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _db.Employees.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<EmployeeDto>(employee);
      
        }

        public async Task<EmployeeDto> GetEmployee(Expression<Func<Employee, bool>> predicate)
        {
            var 
        }

        public IEnumerable<EmployeeDto> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDto> AddOrUpdateEmployee(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
