using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class SchedulesRepository : Repository, ISchedulesRepository
{
    public SchedulesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Schedule> AddAsync(Schedule t) => throw new NotImplementedException();
}
