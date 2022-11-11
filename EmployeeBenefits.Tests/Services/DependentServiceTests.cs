using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services;
using Moq;
using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Tests.Services
{
    [TestFixture]
    public class DependentServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IDependentRepository> _mockDependentRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            var mockDependents = new List<Dependent>
            {
                new() { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" },
                new() { EmployeeId = 1, DependentType = DependentType.Child, FirstName = "Junior", LastName = "Smith" }
            };

            _mockDependentRepository = _mockRepository.Create<IDependentRepository>();
            _mockDependentRepository.Setup(
                x => x.GetDependents(1)).ReturnsAsync(mockDependents);

            _mockDependentRepository.Setup(
                x => x.GetDependentById(1)).ReturnsAsync(new Dependent { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" });

            _mockDependentRepository.Setup(
                x => x.AddOrUpdateDependent(It.IsAny<Dependent>())).ReturnsAsync(new Dependent { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" });

            _mockDependentRepository.Setup(x => x.DeleteDependent(1)).ReturnsAsync(true);

        }

        private DependentService CreateService()
        {
            return new DependentService(_mockDependentRepository.Object);
        }

        [Test]
        public async Task GetDependents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.GetDependents(id);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetDependentById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.GetDependentById(id);

            // Assert
            Assert.AreEqual("Nancy", result.FirstName);
        }

        [Test]
        public async Task AddOrUpdateDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();

            var dependent = new Dependent
                { EmployeeId = 1, DependentType = DependentType.Spouse, FirstName = "Nancy", LastName = "Smith" };

            // Act
            var result = await service.AddOrUpdateDependent(dependent);

            // Assert
            Assert.AreEqual("Nancy", result.FirstName);
        }

        [Test]
        public async Task DeleteDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 1;

            // Act
            var result = await service.DeleteDependent(id);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
