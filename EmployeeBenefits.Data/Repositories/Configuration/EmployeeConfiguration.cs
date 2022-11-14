using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBenefits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeBenefits.Data.Repositories.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder.HasData(

                new Employee
                {
                    Id = 1,
                    FirstName = "John", 
                    LastName = "Smith"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Betty",
                    LastName = "Jones"
                }
            );
        }
    }
}
