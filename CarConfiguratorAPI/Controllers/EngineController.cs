using CarConfiguratorAPI.Data;
using CarConfiguratorAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfiguratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly CarConfigDbContext _context;

        public EngineController(CarConfigDbContext context)
        {
            _context = context;
        }

        // GET: api/Engine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineModel>>> GetEngines()
        {
            return await _context.Engines.ToListAsync();
        }

        // GET: api/Engine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineModel>> GetEngineModel(int id)
        {
            var engineModel = await _context.Engines.FindAsync(id);

            if (engineModel == null)
            {
                return NotFound();
            }

            return engineModel;
        }

        // PUT: api/Engine/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngineModel(int id, EngineModel engineModel)
        {
            engineModel.Id = id;

            _context.Entry(engineModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineModelExists(id))
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

        // POST: api/Engine
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EngineModel>> PostEngineModel(EngineModel engineModel)
        {
            _context.Engines.Add(engineModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EngineModelExists(engineModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEngineModel", new { id = engineModel.Id }, engineModel);
        }

        // DELETE: api/Engine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EngineModel>> DeleteEngineModel(int id)
        {
            var engineModel = await _context.Engines.FindAsync(id);
            if (engineModel == null)
            {
                return NotFound();
            }

            _context.Engines.Remove(engineModel);
            await _context.SaveChangesAsync();

            return engineModel;
        }

        private bool EngineModelExists(int id)
        {
            return _context.Engines.Any(e => e.Id == id);
        }
    }
}
