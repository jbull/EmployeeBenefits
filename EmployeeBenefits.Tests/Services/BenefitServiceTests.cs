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
            _mockRepository = new MockRepository(MockBehavior.Default);

            var mockEmployees = new List<Employee>
            {
                new() { Id = 1, FirstName = "Aaron", LastName = "Smith" }
            };

            var mockDependents = new List<Dependent>
            {
                new() { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" },
                new() { EmployeeId = 1, DependentType = DependentType.Child, FirstName = "Junior", LastName = "Smith" }
            };

            _mockEmployeeRepository = _mockRepository.Create<IEmployeeRepository>();
            _mockEmployeeRepository.Setup(
                x => x.GetEmployeeById(1)).ReturnsAsync(new Employee { Id = 1, FirstName = "Aaron", LastName = "Smith" });


            _mockDependentRepository = _mockRepository.Create<IDependentRepository>();
            _mockDependentRepository.Setup(
                x => x.GetDependents(1)).ReturnsAsync(mockDependents);

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

            Assert.AreEqual(2, result.Dependents);
            Assert.AreEqual(52000.00, result.YearlySalary);
            Assert.AreEqual(2000.00, result.CheckGrossPay);
            Assert.AreEqual(1400.00, result.YearlyCost);
            Assert.AreEqual(53.85, result.CostPerCheck);
            Assert.AreEqual(100.00, result.Discounts);
        }
    }
}
