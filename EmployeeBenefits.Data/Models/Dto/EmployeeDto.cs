namespace EmployeeBenefits.Data.Models.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public List<Dependent>? Dependents { get; set; }

        public decimal MonthlyCost { get; set; }

        public decimal YearlyCost { get; set; }
    }
}
