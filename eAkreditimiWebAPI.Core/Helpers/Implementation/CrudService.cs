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
            This.Add(entity);
            Save();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            This.AddRange(entities);
            Save();
        }

        public TEntity Get(int id) => This.Find(id);


        public IEnumerable<TEntity> GetAll() => This.ToList();


        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate) => This.Where(predicate);


        public void Remove(TEntity entity)
        {
            This.Remove(entity);
            Save();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            This.RemoveRange(entities);
            Save();
        }

        public void Update(TEntity entity)
        {
            This.Update(entity);
            Save();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            This.UpdateRange(entities);
            Save();
        }
        public TEntity UpdateAndGet(TEntity entity)
        {
            var ret = This.Update(entity);
            Save();
            return ret.Entity;
        }

    }
}
