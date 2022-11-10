using EmployeeBenefits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
