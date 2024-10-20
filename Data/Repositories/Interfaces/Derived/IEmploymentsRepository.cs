using Data.Repositories.Interfaces.Base;
using Domain;

namespace Data.Repositories.Interfaces.Derived;
public interface IEmploymentsRepository : IRepository<Employment>
{
}
