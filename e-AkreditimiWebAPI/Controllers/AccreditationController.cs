using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using e_AkreditimiWebAPI.Infrastructure.Models;
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
                return Ok(false);
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
    }
}