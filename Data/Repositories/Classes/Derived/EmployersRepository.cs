using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class EmployersRepository : Repository, IEmployersRepository
{
    public EmployersRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Employer> AddAsync(Employer t)
    {
        throw new NotImplementedException();
    }
}
