using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IGenericRepository
{
    public interface IFullRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task Create(T entity);
        Task Update(Guid id, T entity);
        Task Delete(Guid id);
    }
}
