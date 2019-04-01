using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eAkreditimiWebAPI.Infrastructure.Data;
using e_AkreditimiWebAPI.Infrastructure.Models;

namespace eAkreditimiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelsController : ControllerBase
    {
        private readonly DataContext _context;

        public EducationLevelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EducationLevels
        [HttpGet]
        public IEnumerable<EducationLevel> GetEducationLevels()
        {
            return _context.EducationLevels;
        }

        // GET: api/EducationLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var educationLevel = await _context.EducationLevels.FindAsync(id);

            if (educationLevel == null)
            {
                return NotFound();
            }

            return Ok(educationLevel);
        }

        // PUT: api/EducationLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel([FromRoute] int id, [FromBody] EducationLevel educationLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EducationLevels
        [HttpPost]
        public async Task<IActionResult> PostEducationLevel([FromBody] EducationLevel educationLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EducationLevels.Add(educationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.Id }, educationLevel);
        }

        // DELETE: api/EducationLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var educationLevel = await _context.EducationLevels.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _context.EducationLevels.Remove(educationLevel);
            await _context.SaveChangesAsync();

            return Ok(educationLevel);
        }

        private bool EducationLevelExists(int id)
        {
            return _context.EducationLevels.Any(e => e.Id == id);
        }
    }
}