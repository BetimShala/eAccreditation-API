using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Models.Authentication
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MaidenName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PersonalNumber { get; set; }
        
        public bool IsMale { get; set; }
        
        public int CountryId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
