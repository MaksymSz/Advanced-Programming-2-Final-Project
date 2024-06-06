using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginTest.Data;
using LoginTest.Models;

namespace LoginTest.ControllersApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Participation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participation>>> GetParticipation()
        {
            return await _context.Participation.ToListAsync();
        }

        // GET: api/Participation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participation>> GetParticipation(int id)
        {
            var participation = await _context.Participation.FindAsync(id);

            if (participation == null)
            {
                return NotFound();
            }

            return participation;
        }

        // PUT: api/Participation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipation(int id, Participation participation)
        {
            if (id != participation.ParticipationId)
            {
                return BadRequest();
            }

            _context.Entry(participation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipationExists(id))
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

        // POST: api/Participation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participation>> PostParticipation(Participation participation)
        {
            _context.Participation.Add(participation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipation", new { id = participation.ParticipationId }, participation);
        }

        // DELETE: api/Participation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipation(int id)
        {
            var participation = await _context.Participation.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }

            _context.Participation.Remove(participation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participation.Any(e => e.ParticipationId == id);
        }
    }
}
