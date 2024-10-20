using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class VacanciesRepository : Repository, IVacanciesRepository
{
    public VacanciesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Vacancy> AddAsync(Vacancy t)
    {
        throw new System.NotImplementedException();
    }
}
