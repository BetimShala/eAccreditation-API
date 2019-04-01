using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_AkreditimiWebAPI.Infrastructure.Models;
using eAkreditimiWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eAkreditimiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : ControllerBase
    {
        private readonly DataContext _context;

        public SemestersController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Semesters
        [HttpGet]
        public IEnumerable<Semester> Get()
        {
            return _context.Semesters;
        }

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var semester = await _context.Semesters.FindAsync(id);

            if (semester == null)
            {
                return NotFound();
            }

            return Ok(semester);
        }

        // POST: api/Semesters
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Semeters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
