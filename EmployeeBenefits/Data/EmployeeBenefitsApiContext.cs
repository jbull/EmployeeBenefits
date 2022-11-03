using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Api.Data
{
    public class EmployeeBenefitsApiContext : DbContext
    {
        public EmployeeBenefitsApiContext (DbContextOptions<EmployeeBenefitsApiContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeBenefits.Data.Models.Employee> Employee { get; set; } = default!;
    }
}
