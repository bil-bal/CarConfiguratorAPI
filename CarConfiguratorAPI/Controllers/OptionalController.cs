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
    public class OptionalController : ControllerBase
    {
        private readonly CarConfigDbContext _context;

        public OptionalController(CarConfigDbContext context)
        {
            _context = context;
        }

        // GET: api/Optional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionalModel>>> GetOptionals()
        {
            return await _context.Optionals.ToListAsync();
        }

        // GET: api/Optional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionalModel>> GetOptionalModel(int id)
        {
            var optionalModel = await _context.Optionals.FindAsync(id);

            if (optionalModel == null)
            {
                return NotFound();
            }

            return optionalModel;
        }

        // PUT: api/Optional/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionalModel(int id, OptionalModel optionalModel)
        {
            optionalModel.Id = id;

            _context.Entry(optionalModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionalModelExists(id))
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

        // POST: api/Optional
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OptionalModel>> PostOptionalModel(OptionalModel optionalModel)
        {
            _context.Optionals.Add(optionalModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OptionalModelExists(optionalModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOptionalModel", new { id = optionalModel.Id }, optionalModel);
        }

        // DELETE: api/Optional/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OptionalModel>> DeleteOptionalModel(int id)
        {
            var optionalModel = await _context.Optionals.FindAsync(id);
            if (optionalModel == null)
            {
                return NotFound();
            }

            _context.Optionals.Remove(optionalModel);
            await _context.SaveChangesAsync();

            return optionalModel;
        }

        private bool OptionalModelExists(int id)
        {
            return _context.Optionals.Any(e => e.Id == id);
        }
    }
}
