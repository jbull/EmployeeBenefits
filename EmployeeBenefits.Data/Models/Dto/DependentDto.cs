namespace EmployeeBenefits.Data.Models.Dto
{
    public class DependentDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
