using e_AkreditimiWebAPI.Infrastructure.Models;
using eAkreditimiWebAPI.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Services.Contract
{
    public interface IAccreditationService : IServiceBase<AccreditationApplication>
    {
        IEnumerable<AccreditationApplication> GetAccreditationApplications();
        IEnumerable<AccreditationStudyProgrammes> GetProgrammes(int id);
        IEnumerable<AccrStudyProgrammesSubjects> GetAccrStudyProgrammes(int id);
        AccreditationStudyProgrammes AddAccrSP(AccreditationStudyProgrammes accreditationStudyProgrammes);
        void AddAccrSPSubjects(IEnumerable<AccrStudyProgrammesSubjects> accrStudyProgrammesSubjects);
    }
}
