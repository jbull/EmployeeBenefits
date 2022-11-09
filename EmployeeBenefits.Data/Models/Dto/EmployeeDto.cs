namespace EmployeeBenefits.Data.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public decimal YearlySalary { get; set; }

        public decimal CheckGrossPay { get; set; }

        public decimal CostPerCheck { get; set; }

        public decimal YearlyCost { get; set; }

        public decimal Discounts { get; set; }

        public int Dependents { get; set; }
    }
}
