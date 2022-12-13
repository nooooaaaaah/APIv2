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
    public class SensorController : ControllerBase
    {
        private readonly SpielmanDBContext _context;
        public SensorController(SpielmanDBContext context)
        {
            _context = context;
        }

        //Get: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensor()
        {
            return await _context.Sensor.ToListAsync();
        }
        // Get api/Sensor/User/5
        [HttpGet("user/{userID:int}")]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetUserSensor(int userID)
        {
            var sensors = _context.Sensors.Where(e => e.UserId == userID);
            if (sensors == null)
            {
                return NotFound();
            }
            return await sensors.ToListAsync();
        }
        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var sensor = await _context.Sensor.FindAsync(id);

            if (sensor == null)
            {
                return NotFound();
            }
            return sensor;
        }
        // PUT: api/Sensor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor sensor)
        {
            if (id != sensor.SensorId)
            {
                return BadRequest();
            }
            _context.Entry(sensor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
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
        // POST: api/Sensor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            _context.Sensor.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensor", new { id = sensor.SensorId }, sensor);
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.Sensor.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            _context.Sensor.Remove(sensor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SensorExists(int id)
        {
            return _context.Sensor.Any(e => e.SensorId == id);
        }

    }
}