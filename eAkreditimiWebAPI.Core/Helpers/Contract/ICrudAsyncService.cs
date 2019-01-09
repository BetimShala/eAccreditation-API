using eAkreditimiWebAPI.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface ICrudAsyncService<TEntity> : IAddAsyncService<TEntity>, IGetAsyncService<TEntity>
    {
    }
}
