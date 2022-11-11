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

            _mockDependentRepository = _mockRepository.Create<IDependentRepository>(mockDependents);
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
            int id = 0;

            // Act
            var result = await service.GetDependents(id);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetDependentById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 0;

            // Act
            var result = await service.GetDependentById(id);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddOrUpdateDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            Dependent dependent = null;

            // Act
            var result = await service.AddOrUpdateDependent(dependent);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            int id = 0;

            // Act
            var result = await service.DeleteDependent(id);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }
    }
}
