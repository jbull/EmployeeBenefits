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
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockDependentRepository = this._mockRepository.Create<IDependentRepository>();
        }

        private DependentService CreateService()
        {
            return new DependentService(this._mockDependentRepository.Object);
        }

        [Test]
        public async Task GetDependents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.GetDependents(id);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetDependentById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.GetDependentById(id);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddOrUpdateDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Dependent dependent = null;

            // Act
            var result = await service.AddOrUpdateDependent(dependent);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteDependent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.DeleteDependent(id);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }
    }
}
