using eAkreditimiWebAPI.Infrastructure;
using eAkreditimiWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Helpers.Implementation
{
    public abstract class ContextBase<TEntity> where TEntity : class, new()
    {
        protected readonly DataContext _context;
        public ContextBase(DataContext context)
        {
            _context = context;
        }



        protected DbSet<TEntity> This => _context.Set<TEntity>();

        protected void Save()
        {
            _context.SaveChanges();
        }
        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
