using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class LogoUrlsesRepository : Repository, ILogoUrlsesRepository
{
    public LogoUrlsesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<LogoUrls> AddAsync(LogoUrls t) => throw new NotImplementedException();
}
