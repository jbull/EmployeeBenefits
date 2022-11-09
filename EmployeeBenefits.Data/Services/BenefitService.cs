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
                const decimal YEARLY_EMPLOYEE_COST = 1000.00M;
                const decimal YEARLY_DEPENDENT_COST = 500.00M;
                const decimal DISCOUNT_AMT = 10.00M;
                const decimal CHECK_GROSS_PAY = 2000.00M;
                const int    PAYCHECHKS_PER_YEAR = 26;
                const decimal YEARLY_SALARY = CHECK_GROSS_PAY * PAYCHECHKS_PER_YEAR;
                const char   DISCOUNT_QUALIFIER = 'A';

                var discounts = 0.00M;
                var yearlyCost = 0.00M;
                var numDependents = 0;

                var employee = await _employeeRepository.GetEmployeeById(id);

                if (employee != null)
                {
                    // does employee get a discount?
                    if (employee.FirstName.StartsWith(DISCOUNT_QUALIFIER))
                    {
                        yearlyCost = YEARLY_DEPENDENT_COST - (YEARLY_EMPLOYEE_COST * DISCOUNT_AMT / 100);

                        discounts = (YEARLY_EMPLOYEE_COST * DISCOUNT_AMT / 100);
                    }
                    else
                    {
                        yearlyCost = YEARLY_EMPLOYEE_COST;
                    }

                    var dependents = await _employeeRepository.GetDependents(id);

                    if (dependents != null)
                    {
                        numDependents = dependents.Count();

                        foreach (var dependent in dependents)
                        {
                            // does dependent get a discount?
                            if (dependent.FirstName.StartsWith(DISCOUNT_QUALIFIER))
                            {
                                yearlyCost += YEARLY_DEPENDENT_COST - (YEARLY_DEPENDENT_COST * DISCOUNT_AMT / 100);

                                discounts += (YEARLY_DEPENDENT_COST * DISCOUNT_AMT / 100);
                            }
                            else
                            {
                                yearlyCost += YEARLY_DEPENDENT_COST;
                            }
                        }
                    }

                    return new BenefitsCostResult
                    {
                        YearlySalary = YEARLY_SALARY,
                        YearlyCost = yearlyCost,
                        CheckGrossPay = Math.Round(CHECK_GROSS_PAY, 2),
                        CostPerCheck = Math.Round(yearlyCost / PAYCHECHKS_PER_YEAR, 2),
                        Discounts = discounts,
                        Dependents = numDependents
                    };
                }

                // something went wrong
                _logger.LogError("Unable to load employee data");

                Console.WriteLine("Unable to load employee data");

                return new BenefitsCostResult();

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                Console.WriteLine(e);

                return new BenefitsCostResult();
            }
        }
    }
}
