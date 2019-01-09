using System;
using System.Collections.Generic;
using System.Text;
using e_AkreditimiWebAPI.Infrastructure.Data.API_TestData;

namespace eAkreditimiWebAPI.Core.Services.API_TestDataService
{
    public class APIService : IAPIService
    {
        public IEnumerable<ARC_API> GetARCData()
        {
            var arcDatas = new List<ARC_API>();

            #region Test Data added to ARC_API Model
            arcDatas.Add(new ARC_API
            {
                FirstName = "Rinor",
                LastName = "Mustafa",
                BirthDate = DateTime.Now.AddYears(-20),
                BirthPlace = "Prishtine",
                CountryId = 2,
                Gender = true,
                MaidenName = null,
                MunicipalityId = 19,
                PersonalNumber = "1242691980"
            });
            arcDatas.Add(new ARC_API
            {
                FirstName = "Agon",
                LastName = "Selimi",
                BirthDate = DateTime.Now.AddYears(-20).AddMonths(-2),
                BirthPlace = "Prishtine",
                CountryId = 2,
                Gender = true,
                MaidenName = null,
                MunicipalityId = 19,
                PersonalNumber = "1242691981"
            });
            arcDatas.Add(new ARC_API
            {
                FirstName = "Alban",
                LastName = "Avdiu",
                BirthDate = DateTime.Now.AddYears(-21).AddMonths(-2),
                BirthPlace = "Prishtine",
                CountryId = 2,
                Gender = true,
                MaidenName = null,
                MunicipalityId = 19,
                PersonalNumber = "1242691982"
            });
            arcDatas.Add(new ARC_API
            {
                FirstName = "Tetovare",
                LastName = "Shala",
                BirthDate = DateTime.Now.AddYears(-20).AddMonths(-5),
                BirthPlace = "Prishtine",
                CountryId = 2,
                Gender = false,
                MaidenName = null,
                MunicipalityId = 19,
                PersonalNumber = "1242691983"
            });
            arcDatas.Add(new ARC_API
            {
                FirstName = "Valdete",
                LastName = "Avdyli",
                BirthDate = DateTime.Now.AddYears(-27).AddMonths(-10).AddDays(1),
                BirthPlace = "Prishtine",
                CountryId = 2,
                Gender = false,
                MaidenName = "Shala",
                MunicipalityId = 19,
                PersonalNumber = "1231941625"
            });
            #endregion

            foreach(var item in arcDatas)
            {
                yield return item;
            }

        }
    }
}
