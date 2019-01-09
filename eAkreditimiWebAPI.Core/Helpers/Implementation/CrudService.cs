using eAkreditimiWebAPI.Core.Helpers;
using eAkreditimiWebAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace eAkreditimiWebAPI.Core.Helpers.Implementation
{
    public abstract class CrudService<TEntity> : ContextBase<TEntity>, ICrudService<TEntity> where TEntity : class, new()
    {
        public CrudService(DataContext context) : base(context){}


        public TEntity Add(TEntity entity)
        {
            __THIS__.Add(entity);
            Save();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            __THIS__.AddRange(entities);
            Save();
        }

        public TEntity Get(int id) => __THIS__.Find(id);


        public IEnumerable<TEntity> GetAll() => __THIS__.ToList();


        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate) => __THIS__.Where(predicate);


        public void Remove(TEntity entity)
        {
            __THIS__.Remove(entity);
            Save();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            __THIS__.RemoveRange(entities);
            Save();
        }

        public void Update(TEntity entity)
        {
            __THIS__.Update(entity);
            Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            __THIS__.UpdateRange(entities);
            Save();
        }
        public TEntity UpdateAndGet(TEntity entity)
        {
            var ret = __THIS__.Update(entity);
            Save();
            return ret.Entity;
        }

    }
}
