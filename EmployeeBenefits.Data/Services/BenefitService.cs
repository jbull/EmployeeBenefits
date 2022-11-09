using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services.Interfaces;
using Microsoft.Extensions.Logging;

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


                var discounts = 0.00M;
                var numDependents = 0;

                var employee = await _employeeRepository.GetEmployeeById(id);

                if (employee != null)
                {
                    // does employee get a discount?
                    var yearlyCost = 0.00M;

                    if (employee.FirstName.StartsWith(Constants.DISCOUNT_QUALIFIER))
                    {
                        yearlyCost = Constants.YEARLY_DEPENDENT_COST - (Constants.YEARLY_EMPLOYEE_COST * Constants.DISCOUNT_AMT / 100);

                        discounts = (Constants.YEARLY_EMPLOYEE_COST * Constants.DISCOUNT_AMT / 100);
                    }
                    else
                    {
                        yearlyCost = Constants.YEARLY_EMPLOYEE_COST;
                    }

                    var dependents = await _employeeRepository.GetDependents(id);

                    if (dependents != null)
                    {
                        numDependents = dependents.Count();

                        foreach (var dependent in dependents)
                        {
                            // does dependent get a discount?
                            if (dependent.FirstName.StartsWith(Constants.DISCOUNT_QUALIFIER))
                            {
                                yearlyCost += Constants.YEARLY_DEPENDENT_COST - (Constants.YEARLY_DEPENDENT_COST * Constants.DISCOUNT_AMT / 100);

                                discounts += (Constants.YEARLY_DEPENDENT_COST * Constants.DISCOUNT_AMT / 100);
                            }
                            else
                            {
                                yearlyCost += Constants.YEARLY_DEPENDENT_COST;
                            }
                        }
                    }

                    return new BenefitsCostResult
                    {
                        YearlySalary = Constants.YEARLY_SALARY,
                        YearlyCost = yearlyCost,
                        CheckGrossPay = Math.Round(Constants.CHECK_GROSS_PAY, 2),
                        CostPerCheck = Math.Round(yearlyCost / Constants.PAYCHECHKS_PER_YEAR, 2),
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
