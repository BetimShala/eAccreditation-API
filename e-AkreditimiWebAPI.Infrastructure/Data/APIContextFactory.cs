using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace eAkreditimiWebAPI.Infrastructure.Data
{
    public class APIContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        static public string _cs = "Server=(localdb)\\mssqllocaldb;Database=eAkreditimi-FIEK;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(_cs);

            return new DataContext(builder.Options);
        }
    }
}
