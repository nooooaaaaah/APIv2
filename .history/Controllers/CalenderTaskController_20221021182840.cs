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
    public class CalenderTaskController : ControllerBase
    {
        private readonly NyapolaDBContext _context;

        public CalenderTaskController(NyapolaDBContext context)
        {
            _context = context;
        }

        // GET: api/CalenderTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalenderTask>>> GetCalenderTasks()
        {
          if (_context.CalenderTasks == null)
          {
              return NotFound();
          }
            return await _context.CalenderTasks.ToListAsync();
        }

        // GET: api/CalenderTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalenderTask>> GetCalenderTask(string id)
        {
          if (_context.CalenderTasks == null)
          {
              return NotFound();
          }
            var calenderTask = await _context.CalenderTasks.FindAsync(id);

            if (calenderTask == null)
            {
                return NotFound();
            }

            return calenderTask;
        }

        // PUT: api/CalenderTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalenderTask(string id, CalenderTask calenderTask)
        {
            if (id != calenderTask.EventTaskId)
            {
                return BadRequest();
            }

            _context.Entry(calenderTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalenderTaskExists(id))
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

        // POST: api/CalenderTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalenderTask>> PostCalenderTask(CalenderTask calenderTask)
        {
          if (_context.CalenderTasks == null)
          {
              return Problem("Entity set 'NyapolaDBContext.CalenderTasks'  is null.");
          }
            _context.CalenderTasks.Add(calenderTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalenderTaskExists(calenderTask.EventTaskId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalenderTask", new { id = calenderTask.EventTaskId }, calenderTask);
        }

        // DELETE: api/CalenderTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalenderTask(string id)
        {
            if (_context.CalenderTasks == null)
            {
                return NotFound();
            }
            var calenderTask = await _context.CalenderTasks.FindAsync(id);
            if (calenderTask == null)
            {
                return NotFound();
            }

            _context.CalenderTasks.Remove(calenderTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalenderTaskExists(string id)
        {
            return (_context.CalenderTasks?.Any(e => e.EventTaskId == id)).GetValueOrDefault();
        }
    }
}
