using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefits.Data.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDependentRepository _dependentRepository;
        private readonly ILogger<BenefitService> _logger;

        public BenefitService(IEmployeeRepository employeeRepository,IDependentRepository dependentRepository, ILogger<BenefitService> logger)
        {
            _employeeRepository = employeeRepository;

            _dependentRepository = dependentRepository;

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

                    if (employee.FirstName.StartsWith(Constants.DiscountQualifier))
                    {
                        yearlyCost = Constants.YearlyDependentCost - (Constants.YearlyEmployeeCost * Constants.DiscountAmt / 100);

                        discounts = (Constants.YearlyEmployeeCost * Constants.DiscountAmt / 100);
                    }
                    else
                    {
                        yearlyCost = Constants.YearlyEmployeeCost;
                    }

                    var dependents = await _dependentRepository.GetDependents(id);

                    if (dependents != null)
                    {
                        numDependents = dependents.Count();

                        foreach (var dependent in dependents)
                        {
                            // does dependent get a discount?
                            if (dependent.FirstName.StartsWith(Constants.DiscountQualifier))
                            {
                                yearlyCost += Constants.YearlyDependentCost - (Constants.YearlyDependentCost * Constants.DiscountAmt / 100);

                                discounts += (Constants.YearlyDependentCost * Constants.DiscountAmt / 100);
                            }
                            else
                            {
                                yearlyCost += Constants.YearlyDependentCost;
                            }
                        }
                    }

                    return new BenefitsCostResult
                    {
                        YearlySalary = Constants.YearlySalary,
                        YearlyCost = yearlyCost,
                        CheckGrossPay = Math.Round(Constants.CheckGrossPay, 2),
                        CostPerCheck = Math.Round(yearlyCost / Constants.PaychecksPerYear, 2),
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
