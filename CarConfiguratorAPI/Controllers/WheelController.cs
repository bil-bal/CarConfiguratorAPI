using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarConfiguratorAPI.Data;
using CarConfiguratorAPI.Data.Models;

namespace CarConfiguratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheelController : ControllerBase
    {
        private readonly CarConfigDbContext _context;

        public WheelController(CarConfigDbContext context)
        {
            _context = context;
        }

        // GET: api/Wheel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WheelModel>>> GetWheels()
        {
            return await _context.Wheels.ToListAsync();
        }

        // GET: api/Wheel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WheelModel>> GetWheelModel(int id)
        {
            var wheelModel = await _context.Wheels.FindAsync(id);

            if (wheelModel == null)
            {
                return NotFound();
            }

            return wheelModel;
        }

        // PUT: api/Wheel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWheelModel(int id, WheelModel wheelModel)
        {
            wheelModel.Id = id;

            _context.Entry(wheelModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WheelModelExists(id))
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

        // POST: api/Wheel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WheelModel>> PostWheelModel(WheelModel wheelModel)
        {
            _context.Wheels.Add(wheelModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WheelModelExists(wheelModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWheelModel", new { id = wheelModel.Id }, wheelModel);
        }

        // DELETE: api/Wheel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WheelModel>> DeleteWheelModel(int id)
        {
            var wheelModel = await _context.Wheels.FindAsync(id);
            if (wheelModel == null)
            {
                return NotFound();
            }

            _context.Wheels.Remove(wheelModel);
            await _context.SaveChangesAsync();

            return wheelModel;
        }

        private bool WheelModelExists(int id)
        {
            return _context.Wheels.Any(e => e.Id == id);
        }
    }
}
