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
    public class AccreditationTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public AccreditationTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccreditationTypes
        [HttpGet]
        public IEnumerable<AccreditationType> GetAccreditationTypes()
        {
            return _context.AccreditationTypes;
        }

        // GET: api/AccreditationTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccreditationType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accreditationType = await _context.AccreditationTypes.FindAsync(id);

            if (accreditationType == null)
            {
                return NotFound();
            }

            return Ok(accreditationType);
        }

        // PUT: api/AccreditationTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccreditationType([FromRoute] int id, [FromBody] AccreditationType accreditationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accreditationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(accreditationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccreditationTypeExists(id))
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

        // POST: api/AccreditationTypes
        [HttpPost]
        public async Task<IActionResult> PostAccreditationType([FromBody] AccreditationType accreditationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccreditationTypes.Add(accreditationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccreditationType", new { id = accreditationType.Id }, accreditationType);
        }

        // DELETE: api/AccreditationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccreditationType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accreditationType = await _context.AccreditationTypes.FindAsync(id);
            if (accreditationType == null)
            {
                return NotFound();
            }

            _context.AccreditationTypes.Remove(accreditationType);
            await _context.SaveChangesAsync();

            return Ok(accreditationType);
        }

        private bool AccreditationTypeExists(int id)
        {
            return _context.AccreditationTypes.Any(e => e.Id == id);
        }
    }
}