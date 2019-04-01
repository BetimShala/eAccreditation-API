using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class AccreditationStudyProgrammes
    {
        public int Id { get; set; }

        public int AccreditationApplicationId { get; set; }
        public AccreditationApplication AccreditationApplication { get; set; }

        public DateTime ApplyDate { get; set; }
        public string ProgrammDescription { get; set; }
        public string SpecialismDescription { get; set; }

        public int EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }

        public string ECTS { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public string DiplomaName { get; set; }
        public string Esac { get; set; }
        public string EsacField { get; set; }
        public string StudyType { get; set; }        
        public int StudyDuration { get; set; }
        public int MaxNumber { get; set; }

        public ICollection<AccrStudyProgrammesSubjects> AccrStudyProgrammesSubjects { get; set; }
    }
}
