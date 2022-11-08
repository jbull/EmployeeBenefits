using EmployeeBenefits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IBenefitService
    {
        Task<BenefitsCostResult> GetBenefitsCost(int id);
    }
}
