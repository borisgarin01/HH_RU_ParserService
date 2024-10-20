using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class ProfessionalRolesRepository : Repository, IProfessionalRolesRepository
{
    public ProfessionalRolesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<ProfessionalRole> AddAsync(ProfessionalRole t) => throw new System.NotImplementedException();
}
