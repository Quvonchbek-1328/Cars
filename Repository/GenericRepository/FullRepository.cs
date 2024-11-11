using Entity.EntityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repository.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class FullRepository<T> : IFullRepository<T> where T : class
    {
        private IDistributedCache _distributedCache;
        private readonly DbEntityContext _context;
        private readonly DbSet<T> _set;
        public FullRepository(DbEntityContext context, IDistributedCache cache)
        {
            _context = context;
            _set = _context.Set<T>();
            _distributedCache = cache;
        }
        public async Task Create(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deleteAction = await _set.FindAsync(id);
            if (deleteAction != null)
            {
                _set.Remove(deleteAction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _set.ToListAsync();
            return result;
        }

        public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            string key = $"member_{id}";
            string? cacheMember = await _distributedCache.GetStringAsync(key, cancellationToken);
            T? model;
            if (string.IsNullOrEmpty(cacheMember))
            {
                model = await _set.FindAsync(id, cancellationToken);
                if (model is null)
                {
                    return model;
                }

                var distributedCacheEntryOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                    SlidingExpiration = TimeSpan.FromMinutes(1) 
                };

                await _distributedCache.SetStringAsync(
                    key,
                    JsonConvert.SerializeObject(model),
                    distributedCacheEntryOptions,
                    cancellationToken);

                return model;
            }

            model = JsonConvert.DeserializeObject<T>(cacheMember,
                new JsonSerializerSettings
                {
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                });

            return model;
        }


        public async Task Update(Guid id, T entity)
        {
            var existingEntity = await _set.FindAsync(id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                await _context.SaveChangesAsync();
            }
        }

    }
}
