using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class SnippetsRepository : Repository, ISnippetsRepository
{
    public SnippetsRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Snippet> AddAsync(Snippet t) => throw new NotImplementedException();
}
