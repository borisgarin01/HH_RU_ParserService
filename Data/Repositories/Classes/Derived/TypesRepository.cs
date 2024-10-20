using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class TypesRepository : Repository, ITypesRepository
{
    public TypesRepository(string connectionString) : base(connectionString)
    {
    }

    public Task<Domain.Type> AddAsync(Domain.Type t) => throw new NotImplementedException();
}
