using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Data.Repositories.Interfaces
{
    public interface IDependentRepository
    {
        Task<IEnumerable<Dependent>> GetDependents(int id);

        Task<Dependent> GetDependentById(int id);

        Task<Dependent> AddOrUpdateDependent(Dependent dependent);

        Task<bool> DeleteDependent(int id);
    }
}
