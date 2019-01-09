using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface IServiceBase<TEntity> : ICrudService<TEntity>, ICrudAsyncService<TEntity>
    {
    }
}
