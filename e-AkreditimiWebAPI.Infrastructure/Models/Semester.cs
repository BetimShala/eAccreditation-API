using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<AccrStudyProgrammesSubjects> AccrStudyProgrammesSubjects { get; set; }

    }
}
