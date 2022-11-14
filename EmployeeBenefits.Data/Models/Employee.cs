namespace EmployeeBenefits.Data.Models
{
    public class Employee : BasePersonEntity
    {
        public virtual IList<Dependent>? Dependents { get; set; }
    }
}
