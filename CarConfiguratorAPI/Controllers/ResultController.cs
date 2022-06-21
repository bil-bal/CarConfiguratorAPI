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
    public class ResultController : ControllerBase
    {
        private readonly CarConfigDbContext _context;

        public ResultController(CarConfigDbContext context)
        {
            _context = context;
        }

        // GET: api/Result
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultModel>>> GetResults()
        {
            return await _context.Results
                .Include(t => t.Engine)
                .Include(t => t.Paint)
                .Include(t => t.Wheel)
                .Include(t => t.Optional).ToListAsync();
        }

        // GET: api/Result/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultModel>> GetResultModel(string id)
        {
            var resultModel = await _context.Results
                .Include(t => t.Engine)
                .Include(t => t.Paint)
                .Include(t => t.Wheel)
                .Include(t => t.Optional)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (resultModel == null)
            {
                return NotFound();
            }

            return resultModel;
        }

        // PUT: api/Result/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultModel(string id, ResultModel resultModel)
        {
            if (id != resultModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(resultModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultModelExists(id))
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

        // POST: api/Result
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResultModel>> PostResultModel(ResultModel resultModel)
        {
            string code = GetUrlCode();

            resultModel.Engine = _context.Engines.Single(x => x.Id == resultModel.Engine.Id);
            resultModel.Paint = _context.Paints.Single(x => x.Id == resultModel.Paint.Id);
            resultModel.Wheel = _context.Wheels.Single(x => x.Id == resultModel.Wheel.Id);
            resultModel.Optional = _context.Optionals.Single(x => x.Id == resultModel.Optional.Id);

            resultModel.Id = code;

            _context.Results.Add(resultModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultModel", new { id = resultModel.Id }, resultModel);
        }

        // DELETE: api/Result/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultModel>> DeleteResultModel(string id)
        {
            var resultModel = await _context.Results.FindAsync(id);
            if (resultModel == null)
            {
                return NotFound();
            }

            _context.Results.Remove(resultModel);
            await _context.SaveChangesAsync();

            return resultModel;
        }

        private bool ResultModelExists(string id)
        {
            return _context.Results.Any(e => e.Id == id);
        }

        private string GetUrlCode()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<char> characters = new List<char>()
    {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','-','_','&'};

            string code = "";
            Random rand = new Random();

            bool urlFound = false;

            while (!urlFound)
            {
                int urlCodeLength = 8;

                for (int i = 0; i < urlCodeLength; i++)
                {
                    int random = rand.Next(0, 3);
                    if (random == 1)
                    {
                        random = rand.Next(0, numbers.Count);
                        code += numbers[random].ToString();
                    }
                    else
                    {
                        random = rand.Next(0, characters.Count);
                        code += characters[random].ToString();
                    }
                }

                if (_context.Results.Where(x => x.Id == code).Count() == 0)
                {
                    urlFound = true;
                }
                else
                {
                    urlCodeLength += 1;
                }
            }

            return code;
        }
    }
}
