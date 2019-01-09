using e_AkreditimiWebAPI.Infrastructure.Data.API_TestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace eAkreditimiWebAPI.Core.Services.API_TestDataService
{
    public interface IAPIService
    {
        IEnumerable<ARC_API> GetARCData();
    }
}
