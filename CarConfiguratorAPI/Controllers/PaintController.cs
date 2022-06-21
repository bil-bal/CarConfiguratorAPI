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
    public class PaintController : ControllerBase
    {
        private readonly CarConfigDbContext _context;

        public PaintController(CarConfigDbContext context)
        {
            _context = context;
        }

        // GET: api/Paint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintModel>>> GetPaints()
        {
            return await _context.Paints.ToListAsync();
        }

        // GET: api/Paint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintModel>> GetPaintModel(int id)
        {
            var paintModel = await _context.Paints.FindAsync(id);

            if (paintModel == null)
            {
                return NotFound();
            }

            return paintModel;
        }

        // PUT: api/Paint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaintModel(int id, PaintModel paintModel)
        {
            paintModel.Id = id;

            _context.Entry(paintModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintModelExists(id))
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

        // POST: api/Paint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaintModel>> PostPaintModel(PaintModel paintModel)
        {
            _context.Paints.Add(paintModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaintModelExists(paintModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaintModel", new { id = paintModel.Id }, paintModel);
        }

        // DELETE: api/Paint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaintModel>> DeletePaintModel(int id)
        {
            var paintModel = await _context.Paints.FindAsync(id);
            if (paintModel == null)
            {
                return NotFound();
            }

            _context.Paints.Remove(paintModel);
            await _context.SaveChangesAsync();

            return paintModel;
        }

        private bool PaintModelExists(int id)
        {
            return _context.Paints.Any(e => e.Id == id);
        }
    }
}
