using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IBenefitService
    {
        Task<BenefitsCostResult> GetBenefitsCost(int id);
    }
}
