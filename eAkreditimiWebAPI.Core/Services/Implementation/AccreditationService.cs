using e_AkreditimiWebAPI.Infrastructure.Models;
using eAkreditimiWebAPI.Core.Helpers.Implementation;
using eAkreditimiWebAPI.Core.Services.Contract;
using eAkreditimiWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Services.Implementation
{
    public class AccreditationService : ServiceBase<AccreditationApplication>, IAccreditationService
    {
        public AccreditationService(DataContext context) : base(context)
        {
        }

        public IEnumerable<AccreditationApplication> GetAccreditationApplications()
        {
            var result = __THIS__.Include(a=>a.AccreditationStudyProgrammes).Include(a => a.Verdict).Include(a => a.University).Include(a => a.AccreditationType);
            return result;
        }

        public IEnumerable<AccreditationStudyProgrammes> GetProgrammes(int id)
        {
            var programmes = _context.AccreditationStudyProgrammes.Include(a=>a.Faculty).Include(a=>a.EducationLevel).AsEnumerable().Where(a => a.AccreditationApplicationId == id);
            //var programmess = _context.AccreditationStudyProgrammes.ToListAsync().Result.Where(a => a.AccreditationApplicationId == id);
            return programmes;
        }

        public AccreditationStudyProgrammes AddAccrSP(AccreditationStudyProgrammes accreditationStudyProgrammes)
        {
             _context.AccreditationStudyProgrammes.Add(accreditationStudyProgrammes);
            _context.SaveChanges();
            return accreditationStudyProgrammes;
        }

        public void AddAccrSPSubjects(IEnumerable<AccrStudyProgrammesSubjects> accrStudyProgrammesSubjects)
        {
            _context.AccrStudyProgrammesSubjects.AddRange(accrStudyProgrammesSubjects);
            _context.SaveChanges();
        }

        public IEnumerable<AccrStudyProgrammesSubjects> GetAccrStudyProgrammes(int id)
        {
            return _context.AccrStudyProgrammesSubjects.Include(x => x.Professor).Include(x => x.Semester).Include(x => x.AccrSP).Where(x => x.AccrSPId == id);
        }
    }
}
