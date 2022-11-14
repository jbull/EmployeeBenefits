using EmployeeBenefits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeBenefits.Data.Repositories.Configuration
{
    internal class DependentConfiguration : IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.ToTable("Dependent");
            builder.HasKey(e => e.Id);

            builder.HasData(

                new Dependent
                {
                    Id = 1,
                    EmployeeId = 1,
                    FirstName = "Becky",
                    LastName = "Jones"
                },
                new Dependent
                {
                    Id = 2,
                    EmployeeId = 1,
                    FirstName = "Andy",
                    LastName = "Jones"
                }
            );
        }
    }
}
