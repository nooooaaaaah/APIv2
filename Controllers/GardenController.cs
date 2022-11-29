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
    public class GardenController : ControllerBase
    {
        private readonly SpielmanDBContext _context;

        public GardenController(SpielmanDBContext context)
        {
            _context = context;
        }

        // GET: api/Garden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garden>>> GetGardens()
        {
            return await _context.Gardens.ToListAsync();
        }

        // GET: api/Garden/user/5
        [HttpGet("user/{userID:int}")]
        public async Task<ActionResult<IEnumerable<Garden>>> GetUserGarden(int userID)
        {
            var gardens = _context.Gardens.Where(e => e.UserId == userID);
            if (gardens == null)
            {
                return NotFound();
            }
            return await gardens.ToListAsync();
        }

        // GET: api/Garden/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Garden>> GetGarden(int id)
        {
            var garden = await _context.Gardens.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }

            return garden;
        }

        // PUT: api/Garden/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarden(int id, Garden garden)
        {
            if (id != garden.GardenId)
            {
                return BadRequest();
            }
            _context.Entry(garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenExists(id))
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

        // POST: api/Garden
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garden>> PostGarden(Garden garden)
        {
            _context.Gardens.Add(garden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarden", new { id = garden.GardenId }, garden);
        }

        // DELETE: api/Garden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarden(int id)
        {
            var garden = await _context.Gardens.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }

            _context.Gardens.Remove(garden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenId == id);
        }
    }
}
