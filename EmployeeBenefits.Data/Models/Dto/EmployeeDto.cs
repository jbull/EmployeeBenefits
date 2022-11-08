namespace EmployeeBenefits.Data.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public List<DependentDto> Dependents { get; set; } = new List<DependentDto>();

        public double MonthlyCost { get; set; }

        public double YearlyCost { get; set; }
    }
}
