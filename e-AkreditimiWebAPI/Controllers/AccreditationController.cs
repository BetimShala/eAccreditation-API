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
        public AccreditationController(IAccreditationService accreditationService)
        {
            _accreditationService = accreditationService;
        }

        [HttpGet("all")]
        public IActionResult GetList()
        {
            var accreditationsList = _accreditationService.GetAccreditationApplications();
            return Ok(JsonConvert.SerializeObject(accreditationsList,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            
        }

        [HttpGet("programmes/{id}")]
        public IActionResult GetProgrammes([FromRoute] int id)
        {
            var programmes = _accreditationService.GetProgrammes(id);
            return Ok(JsonConvert.SerializeObject(programmes,
               Formatting.Indented,
               new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
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
                Debug.WriteLine(e.Message);
                return Ok(new { e.InnerException.Message });
            }
        }

        [HttpGet("program/{id}/subjects")]
        public IActionResult GetAccrStudyProgrammes([FromRoute] int id)
        {
            var subjects = _accreditationService.GetAccrStudyProgrammes(id);
            return Ok(JsonConvert.SerializeObject(subjects,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }

        [HttpPost("sems/subjects")]
        public IActionResult GetSubjectsFromSems([FromBody] SEMS_API data)
        {
            var client = new HttpClient();
            var response = client.GetAsync(string.Format("http://127.0.0.1:3100/api/subjects?facultyId={0}&educationLevelId={1}",data.FacultyId,data.EducationLevelId)).Result;
            var content = response.Content.ReadAsStringAsync()
                                       .Result
                                       .Replace("\\", "")
                                       .Trim(new char[1] { '"' });
            var subjects = JsonConvert.DeserializeObject<List<SEMS_API>>(content);
            return Ok(subjects);
        }
    }
}