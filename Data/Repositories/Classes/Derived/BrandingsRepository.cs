using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class BrandingsRepository : Repository, IBrandingsRepository
{
    public BrandingsRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Branding> AddAsync(Branding branding)
    {
        throw new NotImplementedException();
    }
}
