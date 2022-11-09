namespace EmployeeBenefits.Data.Models
{
    public class BenefitsCostResult
    {
        public decimal YearlySalary { get; set; }

        public decimal CheckGrossPay { get; set; }

        public decimal CostPerCheck { get; set; }

        public decimal YearlyCost { get; set; }

        public decimal Discounts { get; set; }

        public int Dependents { get; set; }
    }
}
