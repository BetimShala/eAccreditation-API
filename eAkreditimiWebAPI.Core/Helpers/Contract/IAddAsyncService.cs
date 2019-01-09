using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface IAddAsyncService<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}
