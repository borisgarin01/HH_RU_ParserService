using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class ExperiencesRepository : Repository, IExperiencesRepository
{
    public ExperiencesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Experience> AddAsync(Experience t) => throw new NotImplementedException();
}
