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
    public class JobController : ControllerBase
    {
        private readonly SpielmanDBContext _context;

        public JobController(SpielmanDBContext context)
        {
            _context = context;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetTask()
        {
            return await _context.Task.ToListAsync();
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _context.Task.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.JobId)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Job
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            _context.Task.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.JobId }, job);
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _context.Task.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Task.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(int id)
        {
            return _context.Task.Any(e => e.JobId == id);
        }
    }
}
