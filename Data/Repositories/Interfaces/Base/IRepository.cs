using System.Threading.Tasks;

namespace Data.Repositories.Interfaces.Base;
public interface IRepository<T> where T : class, new()
{
    public Task<T> AddAsync(T t);
}
