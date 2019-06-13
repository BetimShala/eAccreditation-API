using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using e_AkreditimiWebAPI.Infrastructure.Models;
using e_AkreditimiWebAPI.Infrastructure.Models.API_Models;
using e_AkreditimiWebAPI.Infrastructure.ViewModels;
using eAkreditimiWebAPI.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eAkreditimiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccreditationController : ControllerBase
    {
        private readonly IAccreditationService _accreditationService;
        IHttpClientFactory _clientFactory;

        public AccreditationController(IAccreditationService accreditationService, IHttpClientFactory clientFactory)
        {
            _accreditationService = accreditationService;
            _clientFactory = clientFactory;

        }

        [HttpGet("all")]
        public IActionResult GetList()
        {
            var accreditationsList = _accreditationService.GetAccreditationApplications();
            return Ok(JsonConvert.SerializeObject(accreditationsList,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Arrays
                }));
            
        }

        [HttpGet("programmes/{id}")]
        public IActionResult GetProgrammes([FromRoute] int id)
        {
            var programmes = _accreditationService.GetProgrammes(id);
            return Ok(JsonConvert.SerializeObject(programmes,
               new JsonSerializerSettings()
               {
                   Formatting = Formatting.Indented,
                   NullValueHandling = NullValueHandling.Ignore,
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                   PreserveReferencesHandling = PreserveReferencesHandling.Arrays
               }));
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AccreditationApplicationVM accreditationApplicationVM)
        {
            try
            {
                var accreditationApplication = accreditationApplicationVM.AccreditationApplication;
                accreditationApplication.VerdictDate = DateTime.Now;
                accreditationApplication.ValidFromDate = DateTime.Now;
                accreditationApplication.ValidToDate = DateTime.Now.AddYears(1);
                accreditationApplication.ApplicationDate = DateTime.Now;
                var application = _accreditationService.Add(accreditationApplication);

                var accreditationStudyProgrammes = accreditationApplicationVM.AccreditationStudyProgrammes;
                accreditationStudyProgrammes.AccreditationApplicationId = application.Id;
                accreditationStudyProgrammes.ApplyDate = DateTime.Now;
                var studyProgrammes = _accreditationService.AddAccrSP(accreditationStudyProgrammes);

                var subjects = accreditationApplicationVM.AccrStudyProgrammesSubjects;
                foreach(var item in subjects)
                {
                    item.AccrSPId = studyProgrammes.Id;
                }
                _accreditationService.AddAccrSPSubjects(accreditationApplicationVM.AccrStudyProgrammesSubjects);

                return Ok(true);
                
            }
            catch(Exception e)
            {
                return Ok(new { e.InnerException.Message });
            }
        }

        [HttpGet("program/{id}/subjects")]
        public IActionResult GetAccrStudyProgrammes([FromRoute] int id)
        {
            var subjects = _accreditationService.GetAccrStudyProgrammes(id);
            return Ok(JsonConvert.SerializeObject(subjects,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Arrays
                }));
        }

        [HttpPost("sems/subjects")]
        public async Task<IActionResult> GetSubjectsFromSems([FromBody] SEMS_API data)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://127.0.0.1:3100/api/subjects?facultyId={data.FacultyId}&educationLevelId={data.EducationLevelId}");
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content
                    .ReadAsAsync<IEnumerable<SEMS_API>>());
            }
            return Ok(null);
        }
    }
}