using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Data.Models
{
    public class BenefitsCostResult
    {
        public double MonthlyCost { get; set; }

        public double YearlyCost { get; set; }

        public double Discount { get; set; }
    }
}
