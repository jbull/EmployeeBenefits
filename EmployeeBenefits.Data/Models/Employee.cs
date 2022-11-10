namespace EmployeeBenefits.Data.Models
{
    public class Employee : BasePersonEntity
    {
        public IList<Dependent>? Dependents { get; set; }
    }
}
