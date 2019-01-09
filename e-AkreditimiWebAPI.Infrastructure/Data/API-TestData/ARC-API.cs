using System;
using System.Collections.Generic;
using System.Text;

namespace e_AkreditimiWebAPI.Infrastructure.Data.API_TestData
{
    public class ARC_API
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public bool Gender { get; set; }
        public string MaidenName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public int MunicipalityId { get; set; }


        //public ARC_API(
        //    string FirstName, string LastName, string PersonalNumber, bool Gender, string MaidenName,string BirthPlace,
        //    DateTime BirthDate,int CountryId,int MunicipalityId)
        //{

        //}
        
    }
}
