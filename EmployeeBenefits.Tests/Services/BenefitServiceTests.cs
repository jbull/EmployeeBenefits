using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeBenefits.Tests.Services
{
    [TestFixture]
    public class BenefitServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private Mock<IDependentRepository> _mockDependentRepository;
        private Mock<ILogger<BenefitService>> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            var mockEmployees = new List<Employee>
            {
                new() { Id = 1, FirstName = "Aaron", LastName = "Smith" }
            };

            var mockDependents = new List<Dependent>
            {
                new() { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" },
                new() { EmployeeId = 1, DependentType = DependentType.Child, FirstName = "Junior", LastName = "Smith" }
            };

            _mockEmployeeRepository = _mockRepository.Create<IEmployeeRepository>(mockEmployees);
            _mockDependentRepository = _mockRepository.Create<IDependentRepository>(mockDependents);
            _mockLogger = _mockRepository.Create<ILogger<BenefitService>>();
        }

        private BenefitService CreateService()
        {
            return new BenefitService(
                _mockEmployeeRepository.Object,
                _mockDependentRepository.Object,
                _mockLogger.Object);
        }

        [Test]
        public async Task GetBenefitsCost_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.GetBenefitsCost(id);

            Assert.AreEqual(1, result.Dependents);
            Assert.AreEqual(1, result.YearlySalary);
            Assert.AreEqual(1, result.CheckGrossPay);
            Assert.AreEqual(1, result.YearlyCost);
            Assert.AreEqual(1, result.CostPerCheck);
            Assert.AreEqual(1, result.Discounts);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }
    }
}
