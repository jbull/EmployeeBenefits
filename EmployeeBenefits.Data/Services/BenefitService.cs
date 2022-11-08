using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Data.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<BenefitService> _logger;

        public BenefitService(IEmployeeRepository employeeRepository, ILogger<BenefitService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<BenefitsCostResult> GetBenefitsCost(int id)
        {
            try
            {
                const double YEARLY_EMPLOYEE_COST = 1000.00;
                const double YEARLY_DEPENDENT_COST = 500.00;
                const double DISCOUNT_AMT = 10.00;

                var discount = 0.00;
                var yearlyTotal = 0.00;

                var employee = await _employeeRepository.GetEmployeeById(id);
                if (employee != null)
                {
                    yearlyTotal = employee.FirstName.StartsWith('A') 
                        ? YEARLY_EMPLOYEE_COST * DISCOUNT_AMT / 100 
                        : YEARLY_EMPLOYEE_COST;

                }

                var dependents = await _employeeRepository.GetDependents(id);
                if (dependents != null)
                {
                    foreach (var dependent in dependents)
                    {
                        yearlyTotal += dependent.FirstName.StartsWith('A')
                        ? YEARLY_DEPENDENT_COST * DISCOUNT_AMT / 100
                        : YEARLY_DEPENDENT_COST;
                    }
                }

                return new BenefitsCostResult
                {
                    YearlyCost = yearlyTotal,
                    MonthlyCost = yearlyTotal / 12,
                    Discount = discount
                };

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
