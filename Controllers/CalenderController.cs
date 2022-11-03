using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIv2.models;

namespace APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly NyapolaDBContext _context;

        public CalenderController(NyapolaDBContext context)
        {
            _context = context;
        }

        // GET: api/Calender
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calender>>> GetCalenders()
        {
            if (_context.Calenders == null)
            {
                return NotFound();
            }
            return await _context.Calenders.ToListAsync();
        }

        // GET: api/Calender/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calender>> GetCalender(int id)
        {
            if (_context.Calenders == null)
            {
                return NotFound();
            }
            var calender = await _context.Calenders.FindAsync(id);

            if (calender == null)
            {
                return NotFound();
            }

            return calender;
        }

        // PUT: api/Calender/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalender(int id, Calender calender)
        {
            if (id != calender.EventId)
            {
                return BadRequest();
            }

            _context.Entry(calender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalenderExists(id))
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

        // POST: api/Calender
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calender>> PostCalender(Calender calender)
        {
            if (_context.Calenders == null)
            {
                return Problem("Entity set 'NyapolaDBContext.Calenders'  is null.");
            }
            _context.Calenders.Add(calender);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalenderExists(calender.EventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalender", new { id = calender.EventId }, calender);
        }

        // DELETE: api/Calender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalender(int id)
        {
            if (_context.Calenders == null)
            {
                return NotFound();
            }
            var calender = await _context.Calenders.FindAsync(id);
            if (calender == null)
            {
                return NotFound();
            }

            _context.Calenders.Remove(calender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalenderExists(int id)
        {
            return (_context.Calenders?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
