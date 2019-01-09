using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AccreditationApplication> AccreditationApplications { get; set; }
        public ICollection<Faculty> Faculties { get; set; }


    }
}
