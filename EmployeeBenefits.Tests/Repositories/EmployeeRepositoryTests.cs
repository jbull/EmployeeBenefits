using EmployeeBenefits.Data.Repositories;
using EmployeeBenefits.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefits.Tests.Repositories
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        string dbName = $"EmpBenefits{DateTime.Now.ToFileTimeUtc()}";
        
        private DbContextOptions<ApplicationDbContext> options;

        protected ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            _context = new ApplicationDbContext(options); 
            _context.Database.EnsureCreated();

            var mockEmployees = new List<Employee>
            {
                new() { Id = 1, FirstName = "Aaron", LastName = "Smith" },
                new() { Id = 2, FirstName = "George", LastName = "Jones" }
            };

            _context.Employees.AddRange(mockEmployees);
            _context.SaveChanges();
        }

        private EmployeeRepository CreateEmployeeRepository()
        {
            return new EmployeeRepository(_context);
        }

        [Test]
        public async Task GetEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();

            // Act
            var result = await employeeRepository.GetEmployees();

            // Assert
            Assert.AreEqual(2,result.Count());
        }

        [Test]
        public async Task GetEmployeeById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 1;

            // Act
            var result = await employeeRepository.GetEmployeeById(id);

            // Assert
            Assert.AreEqual("Aaron", result.FirstName);
        }


        [Test]
        public async Task AddOrUpdateEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();

            var employee = new Employee
            {
                FirstName = "Peet", LastName = "Wilson"
            };

            // Act
            var result = await employeeRepository.AddOrUpdateEmployee(employee);

            // Assert
            Assert.AreEqual("Peet", result.FirstName);
        }

        [Test]
        public async Task DeleteEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 1;

            // Act
            var result = await employeeRepository.DeleteEmployee(id);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
