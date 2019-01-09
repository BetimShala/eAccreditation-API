using e_AkreditimiWebAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AccreditationApplication> AccreditationApplications { get; set; }
        public DbSet<AccreditationStudyProgrammes> AccreditationStudyProgrammes { get; set; }
        public DbSet<AccrStudyProgrammesSubjects> AccrStudyProgrammesSubjects { get; set; }        
        public DbSet<AcademicStaffCommitments> AcademicStaffCommitments { get; set; }
        public DbSet<AccreditationType> AccreditationTypes { get; set; }
        public DbSet<Verdict> Verdicts { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        
    }
}
