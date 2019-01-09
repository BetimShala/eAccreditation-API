using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface ICrudService<TEntity> : IAddService<TEntity>, IGetService<TEntity>, IUpdateService<TEntity>, IDeleteService<TEntity>
    {
    }
}
