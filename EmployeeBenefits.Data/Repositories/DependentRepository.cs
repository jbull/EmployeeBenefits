using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefits.Data.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly ApplicationDbContext _db;

        public DependentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Dependent>> GetDependents(int id)
        {
            var dependents = await _db.Dependents.Where(x=> x.EmployeeId == id).ToListAsync();

            return dependents;
        }

        public async Task<Dependent> GetDependentById(int id)
        {
            var dependent = await _db.Dependents.SingleOrDefaultAsync(x => x.Id == id);

            return dependent;

        }

        public async Task<Dependent> AddOrUpdateDependent(Dependent dependent)
        {
            if (dependent.Id > 0)
            {
                _db.Dependents.Update(dependent);
            }
            else
            {
                _db.Dependents.Add(dependent);
            }

            await _db.SaveChangesAsync();

            return dependent;
        }

        public async Task<bool> DeleteDependent(int id)
        {
            try
            {
                var dependent = await _db.Dependents.FirstOrDefaultAsync(x => x.Id == id);
                if (dependent == null)
                {
                    return false;
                }

                _db.Dependents.Remove(dependent);

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
