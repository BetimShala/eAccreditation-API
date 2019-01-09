using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class AccreditationApplication
    {
        public int Id { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public int MeetingId { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public DateTime? ValidToDate { get; set; }
        public DateTime? VerdictDate { get; set; }

        public int VerdictId { get; set; }
        public Verdict Verdict { get; set; }

        public int AccreditationTypeId { get; set; }
        public AccreditationType AccreditationType { get; set; }

        public string AcademicYear { get; set; }

        public ICollection<AccreditationStudyProgrammes> AccreditationStudyProgrammes { get; set; }
    }
}
