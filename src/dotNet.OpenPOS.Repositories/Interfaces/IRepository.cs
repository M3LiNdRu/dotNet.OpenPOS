using dotNet.OpenPOS.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
