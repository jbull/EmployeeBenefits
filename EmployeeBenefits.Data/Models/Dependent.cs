namespace EmployeeBenefits.Data.Models
{
    public class Dependent: BasePersonEntity
    {
        public int EmployeeId { get; set; }

        public DependentType DependentType { get; set; }

    }
}
