using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models.API_Models
{
    public class SEMS_API
    {
        public int FacultyId { get; set; }
        public int EducationLevelId { get; set; }
        public int SemesterId { get; set; }
        public int ExercisesNum { get; set; }
        public int CreditsNum { get; set; }
        public int ConsultationNum { get; set; }
        public int ClinicNum { get; set; }
        public int PracticeNum { get; set; }
        public int ResearchNum { get; set; }
        public int LecturesNum { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
    }
}
