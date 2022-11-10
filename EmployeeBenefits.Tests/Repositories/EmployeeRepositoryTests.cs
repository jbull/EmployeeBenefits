using EmployeeBenefits.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Tests.Repositories
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private EmployeeRepository CreateEmployeeRepository()
        {
            return new EmployeeRepository(
                this.mockApplicationDbContext.Object);
        }

        [Test]
        public async Task GetEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();

            // Act
            var result = await employeeRepository.GetEmployees();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetEmployeeById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 0;

            // Act
            var result = await employeeRepository.GetEmployeeById(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            Expression predicate = null;

            // Act
            var result = await employeeRepository.GetEmployee(
                predicate);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            Expression predicate = null;

            // Act
            var result = await employeeRepository.FindEmployees(
                predicate);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddOrUpdateEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            Employee employee = null;

            // Act
            var result = await employeeRepository.AddOrUpdateEmployee(
                employee);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 0;

            // Act
            var result = await employeeRepository.DeleteEmployee(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetDependents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 0;

            // Act
            var result = await employeeRepository.GetDependents(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddOrUpdateDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            Dependent dependent = null;

            // Act
            var result = await employeeRepository.AddOrUpdateDependent(
                dependent);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeRepository = this.CreateEmployeeRepository();
            int id = 0;

            // Act
            var result = await employeeRepository.DeleteDependent(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
