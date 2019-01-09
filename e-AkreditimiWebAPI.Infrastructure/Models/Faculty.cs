using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<AccreditationStudyProgrammes> AccreditationStudyProgrammes { get; set; }
        public ICollection<AcademicStaffCommitments> AcademicStaffCommitments { get; set; }


    }
}
