using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers
{
    public interface IAddService<TEntity>
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}
