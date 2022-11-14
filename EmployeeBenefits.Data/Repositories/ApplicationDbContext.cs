using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefits.Data.Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Dependent> Dependents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new DependentConfiguration());
    }
}