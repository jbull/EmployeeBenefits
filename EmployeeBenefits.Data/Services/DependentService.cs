using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using EmployeeBenefits.Data.Services.Interfaces;

namespace EmployeeBenefits.Data.Services
{
    public class DependentService: IDependentService
    {
        private readonly IDependentRepository _dependentRepository;

        public DependentService(IDependentRepository dependentRepository)
        {
            _dependentRepository = dependentRepository;
        }

        public async Task<IEnumerable<Dependent>> GetDependents(int id)
        {
            return await _dependentRepository.GetDependents(id);
        }

        public async Task<Dependent> GetDependentById(int id)
        {
            return await _dependentRepository.GetDependentById(id);
        }

        public async Task<Dependent> AddOrUpdateDependent(Dependent dependent)
        { 
            return await _dependentRepository.AddOrUpdateDependent(dependent);
        }

        public async Task<bool> DeleteDependent(int id)
        {
            return await _dependentRepository.DeleteDependent(id);
        }
    }
}
