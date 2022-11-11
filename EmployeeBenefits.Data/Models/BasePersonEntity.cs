using System.ComponentModel.DataAnnotations;

namespace EmployeeBenefits.Data.Models
{
    public class BasePersonEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

    }
}
