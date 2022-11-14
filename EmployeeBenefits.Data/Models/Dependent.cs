using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeBenefits.Data.Models
{
    public class Dependent: BasePersonEntity
    {
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }


        public DependentType DependentType { get; set; }

    }
}
