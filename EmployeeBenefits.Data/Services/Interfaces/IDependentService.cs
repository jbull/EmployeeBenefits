using EmployeeBenefits.Data.Models;

namespace EmployeeBenefits.Data.Services.Interfaces
{
    public interface IDependentService
    {
        Task<IEnumerable<Dependent>> GetDependents(int id);

        Task<Dependent> GetDependentById(int id);

        Task<Dependent> AddOrUpdateDependent(Dependent dependent);

        Task<bool> DeleteDependent(int id);
    }
}
