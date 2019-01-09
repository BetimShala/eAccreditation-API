using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface IDeleteService<TEntity>
    {
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
