using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meeup01.Data;
using Meeup01.Models;

namespace Meeup01.Areas.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SuspectsController : ControllerBase
    {
        private readonly AppDb _context;

        public SuspectsController(AppDb context)
        {
            _context = context;
        }

        // GET: api/Suspects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suspect>>> GetSuspects()
        {
            return await _context.Suspects.ToListAsync();
        }

        // GET: api/Suspects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suspect>> GetSuspect(int id)
        {
            var suspect = await _context.Suspects.FindAsync(id);

            if (suspect == null)
            {
                return NotFound();
            }

            return suspect;
        }

        // PUT: api/Suspects/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuspect(int id, Suspect suspect)
        {
            if (id != suspect.Id)
            {
                return BadRequest();
            }

            _context.Entry(suspect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectExists(id))
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

        // POST: api/Suspects
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Suspect>> PostSuspect(Suspect suspect)
        {
            _context.Suspects.Add(suspect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuspect", new { id = suspect.Id }, suspect);
        }

        // DELETE: api/Suspects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suspect>> DeleteSuspect(int id)
        {
            var suspect = await _context.Suspects.FindAsync(id);
            if (suspect == null)
            {
                return NotFound();
            }

            _context.Suspects.Remove(suspect);
            await _context.SaveChangesAsync();

            return suspect;
        }

        private bool SuspectExists(int id)
        {
            return _context.Suspects.Any(e => e.Id == id);
        }
    }
}
