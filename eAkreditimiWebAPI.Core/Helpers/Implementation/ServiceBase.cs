using eAkreditimiWebAPI.Core.Helpers;
using eAkreditimiWebAPI.Infrastructure;
using eAkreditimiWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers.Implementation
{
    public abstract class ServiceBase<TEntity> : ContextBase<TEntity>, IServiceBase<TEntity> where TEntity : class, new()
    {
        public ServiceBase(DataContext context) : base(context)
        {
        }

        public TEntity Add(TEntity entity)
        {
            This.Add(entity);
            Save();
            return entity;
        }


        public async Task AddAsync(TEntity entity)
        {
            await This.AddAsync(entity);
            await SaveAsync();
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            This.AddRange(entities);
            Save();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await This.AddRangeAsync(entities);
            await SaveAsync();
        }

        public TEntity Get(int id) => This.Find(id);


        public IEnumerable<TEntity> GetAll() => This.ToList();


        public async Task<TEntity> GetAsync(int id) => await This.FindAsync(id);


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

        public TEntity UpdateAndGet(TEntity entity)
        {
            var ret = This.Update(entity);
            Save();
            return ret.Entity;

        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            This.UpdateRange(entities);
            Save();
        }

    }
}
