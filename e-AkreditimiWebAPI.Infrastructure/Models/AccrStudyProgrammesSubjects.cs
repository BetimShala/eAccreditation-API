using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class AccrStudyProgrammesSubjects
    {
        public int Id { get; set; }

        public int AccrSPId { get; set; }
        public AccreditationStudyProgrammes AccrSP { get; set; }

        public string ProfessorId { get; set; }
        public ApplicationUser Professor { get; set; }

        public string Description { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public int ExercisesNum { get; set; }
        public int CreditsNum { get; set; }
        public int ConsultationNum { get; set; }
        public int ClinicNum { get; set; }
        public int PracticeNum { get; set; }
        public int ResearchNum { get; set; }
        public int LecturesNum { get; set; }
        public string SubjectCode { get; set; }

    }
}
