using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services;
using Moq;
using System.Linq.Expressions;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Tests.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IEmployeeRepository> _mockEmployeeRepository;

        [SetUp]
        public void SetUp()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockEmployeeRepository = this._mockRepository.Create<IEmployeeRepository>();
        }

        private EmployeeService CreateService()
        {
            return new EmployeeService(this._mockEmployeeRepository.Object);
        }

        [Test]
        public async Task GetEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GetEmployees();

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetEmployeeById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.GetEmployeeById(id);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }


        [Test]
        public async Task AddOrUpdateEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Employee employee = null;

            // Act
            var result = await service.AddOrUpdateEmployee(employee);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.DeleteEmployee(id);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }
    }
}
