using System.ComponentModel.DataAnnotations;

namespace EmployeeBenefits.Data.Models
{
    public class BasePersonEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
