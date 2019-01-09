
using eAkreditimiWebAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers.Implementation
{
    public abstract class CrudAsync<TEntity> : ContextBase<TEntity>, ICrudAsyncService<TEntity> where TEntity : class, new()
    {
        public CrudAsync(DataContext context) : base(context) {}

        public async Task AddAsync(TEntity entity)
        {
            await __THIS__.AddAsync(entity);
            await SaveAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await __THIS__.AddRangeAsync(entities);
            await SaveAsync();
        }

        public async Task<TEntity> GetAsync(int id) => await __THIS__.FindAsync(id);
    }
}
