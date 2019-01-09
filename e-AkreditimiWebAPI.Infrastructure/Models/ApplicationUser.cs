using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string PersonalNumber { get; set; }
        public bool IsMale { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<AccrStudyProgrammesSubjects> AccrStudyProgrammesSubjects { get; set; }
        public ICollection<AcademicStaffCommitments> AcademicStaffCommitments { get; set; }

    }
}
