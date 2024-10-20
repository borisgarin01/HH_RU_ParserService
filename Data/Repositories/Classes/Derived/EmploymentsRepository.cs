using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class EmploymentsRepository : Repository, IEmploymentsRepository
{
    public EmploymentsRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Employment> AddAsync(Employment t)
    {
        throw new NotImplementedException();
    }
}
