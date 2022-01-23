using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiresController : ControllerBase
    {
        private readonly WebApplication6Context _context;

        public HiresController(WebApplication6Context context)
        {
            _context = context;
        }

        // GET: api/Hires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hire>>> GetHire()
        {
            return await _context.Hire.ToListAsync();
        }

        // GET: api/Hires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hire>> GetHire(int id)
        {
            var hire = await _context.Hire.FindAsync(id);

            if (hire == null)
            {
                return NotFound();
            }

            return hire;
        }

        // PUT: api/Hires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHire(int id, Hire hire)
        {
            if (id != hire.Id)
            {
                return BadRequest();
            }

            _context.Entry(hire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HireExists(id))
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

        // POST: api/Hires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hire>> PostHire(Hire hire)
        {
            _context.Hire.Add(hire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHire", new { id = hire.Id }, hire);
        }

        // DELETE: api/Hires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHire(int id)
        {
            var hire = await _context.Hire.FindAsync(id);
            if (hire == null)
            {
                return NotFound();
            }

            _context.Hire.Remove(hire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HireExists(int id)
        {
            return _context.Hire.Any(e => e.Id == id);
        }
    }
}
