using e_AkreditimiWebAPI.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.ViewModels
{
    public class AccreditationApplicationVM
    {

        public AccreditationApplication AccreditationApplication { get; set; }
        public AccreditationStudyProgrammes AccreditationStudyProgrammes { get; set; }
        public List<AccrStudyProgrammesSubjects> AccrStudyProgrammesSubjects { get; set; }
    }
}
