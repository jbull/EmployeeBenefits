using EmployeeBenefits.Data.Repositories;
using EmployeeBenefits.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefits.Tests.Repositories
{
    [TestFixture]
    public class DependentRepositoryTests
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
            _context.Database.EnsureDeleted();

            var dependents = new List<Dependent>
            {
                new() { Id = 1, EmployeeId = 1, FirstName = "Aaron", LastName = "Smith" },
                new() { Id = 2, EmployeeId = 1, FirstName = "George", LastName = "Jones" }
            };

            _context.Dependents.AddRange(dependents);
            _context.SaveChanges();
        }

        private DependentRepository CreateDependentRepository()
        {
            return new DependentRepository(_context);
        }

        [Test]
        public async Task GetDependents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dependentRepository = CreateDependentRepository();
            int id = 1;

            // Act
            var result = await dependentRepository.GetDependents(id);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetDependentById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dependentRepository = CreateDependentRepository();
            int id = 1;

            // Act
            var result = await dependentRepository.GetDependentById(id);

            // Assert
            Assert.AreEqual("Aaron", result.FirstName);
        }

        [Test]
        public async Task AddOrUpdateDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dependentRepository = CreateDependentRepository();

            var dependent = new Dependent
            {
                EmployeeId = 1, FirstName = "Donny", LastName = "Smith"
            };

            // Act
            var result = await dependentRepository.AddOrUpdateDependent(dependent);

            // Assert
            Assert.AreEqual("Donny", result.FirstName);
        }

        [Test]
        public async Task DeleteDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dependentRepository = CreateDependentRepository();
            int id = 1;

            // Act
            var result = await dependentRepository.DeleteDependent(id);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
