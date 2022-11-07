namespace EmployeeBenefits.Data.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public List<DependentDto> Dependents { get; set; } = new List<DependentDto>();

        public decimal MonthlyCost { get; set; }

        public decimal YearlyCost { get; set; }
    }
}
