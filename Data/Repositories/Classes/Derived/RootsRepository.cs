using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class RootsRepository : Repository, IRootsRepository
{
    public RootsRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Root> AddAsync(Root t) => throw new NotImplementedException();
}
