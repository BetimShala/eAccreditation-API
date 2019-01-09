using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface IGetAsyncService<TEntity>
    {
        Task<TEntity> GetAsync(int id);
    }
}
