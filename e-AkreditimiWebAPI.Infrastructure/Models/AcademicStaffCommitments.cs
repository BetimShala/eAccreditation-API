using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class AcademicStaffCommitments
    {
        public int Id { get; set; }
        //public int StaffId { get; set; }
        public ApplicationUser Staff { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public string AcademicYear { get; set; }
        public DateTime? DeclarationDate { get; set; }

    }
}
