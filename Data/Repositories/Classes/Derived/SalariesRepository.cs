using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class SalariesRepository : Repository, ISalariesRepository
{
    public SalariesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Salary> AddAsync(Salary t) => throw new NotImplementedException();
}
