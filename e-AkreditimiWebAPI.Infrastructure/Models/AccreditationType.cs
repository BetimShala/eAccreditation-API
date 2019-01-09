using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models
{
    public class AccreditationType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<AccreditationApplication> AccreditationApplications { get; set; }

    }
}
