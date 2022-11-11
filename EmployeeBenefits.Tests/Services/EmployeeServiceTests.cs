using System.Collections;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services;
using Moq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
            _mockRepository = new MockRepository(MockBehavior.Default);

            IEnumerable<Employee> mockEmployees = new Employee[]
            {
                new() { Id = 1, FirstName = "Aaron", LastName = "Smith" },
                new() { Id = 2, FirstName = "George", LastName = "Jones" }
            };


            _mockEmployeeRepository = _mockRepository.Create<IEmployeeRepository>();
            
            _mockEmployeeRepository.Setup(
                x => x.GetEmployees()).ReturnsAsync(mockEmployees);
            
            _mockEmployeeRepository.Setup(
                x => x.GetEmployeeById(1)).ReturnsAsync(new Employee { Id = 1, FirstName = "Aaron", LastName = "Smith" });
            
            _mockEmployeeRepository.Setup(
                x => x.AddOrUpdateEmployee(It.IsAny<Employee>())).ReturnsAsync(new Employee { Id = 3, FirstName = "Nancy", LastName = "Jones" });

            _mockEmployeeRepository.Setup(x => x.DeleteEmployee(1)).ReturnsAsync(true);


        }

        private EmployeeService CreateService()
        {
            return new EmployeeService(_mockEmployeeRepository.Object);
        }

        [Test]
        public async Task GetEmployees_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();

            // Act
            var result = await service.GetEmployees();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetEmployeeById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.GetEmployeeById(id);

            // Assert
            Assert.AreEqual("Aaron", result.FirstName);
        }


        [Test]
        public async Task AddOrUpdateEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();

            var employee = new Employee
            {
                FirstName = "Nancy",
                LastName = "Jones"
            };

            // Act
            var result = await service.AddOrUpdateEmployee(employee);

            // Assert
            Assert.AreEqual("Nancy", result.FirstName);
        }

        [Test]
        public async Task DeleteEmployee_StateUnderTest_ExpectedBehavior()
        {
            // Arrang
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.DeleteEmployee(id);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
