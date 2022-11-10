using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services;
using Microsoft.Extensions.Logging;
using Moq;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Tests.Services
{
    [TestFixture]
    public class BenefitServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<ILogger<BenefitService>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            
            var mockEmployees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Aaron", LastName = "Smith" }
            };

            var mockDependents = new List<Dependent>
            {
                new Dependent
                    { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" }
            };

            this.mockEmployeeRepository = this.mockRepository.Create<IEmployeeRepository>(mockEmployees);
            this.mockLogger = this.mockRepository.Create<ILogger<BenefitService>>();
        }

        private BenefitService CreateService()
        {
            return new BenefitService(
                this.mockEmployeeRepository.Object,
                this.mockLogger.Object);
        }

        [Test]
        public async Task GetBenefitsCost_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

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
            this.mockRepository.VerifyAll();
        }
    }
}
