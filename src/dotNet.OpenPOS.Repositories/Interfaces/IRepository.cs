using dotNet.OpenPOS.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> FindByCodeAsync(string code);
        Task<T> FindByNameAsync(string name);
        bool InsertAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteAsync(int id);
    }
}
