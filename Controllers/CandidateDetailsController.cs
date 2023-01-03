using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementAPI.Data;
using ManagementAPI.Models;

namespace ManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateDetailsController : ControllerBase
    {
        private readonly ManagementDb _context;

        public CandidateDetailsController(ManagementDb context)
        {
            _context = context;
        }

        // GET: api/CandidateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDetails>>> GetCandidateDetails()
        {
            return await _context.CandidateDetails.ToListAsync();
        }

        // GET: api/CandidateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDetails>> GetCandidateDetails(int id)
        {
            var candidateDetails = await _context.CandidateDetails.FindAsync(id);

            if (candidateDetails == null)
            {
                return NotFound();
            }

            return candidateDetails;
        }

        // PUT: api/CandidateDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidateDetails(int id, CandidateDetails candidateDetails)
        {
            if (id != candidateDetails.ID)
            {
                return BadRequest();
            }

            _context.Entry(candidateDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateDetailsExists(id))
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

        // POST: api/CandidateDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandidateDetails>> PostCandidateDetails(CandidateDetails candidateDetails)
        {
            _context.CandidateDetails.Add(candidateDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidateDetails", new { id = candidateDetails.ID }, candidateDetails);
        }

        // DELETE: api/CandidateDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateDetails(int id)
        {
            var candidateDetails = await _context.CandidateDetails.FindAsync(id);
            if (candidateDetails == null)
            {
                return NotFound();
            }

            _context.CandidateDetails.Remove(candidateDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateDetailsExists(int id)
        {
            return _context.CandidateDetails.Any(e => e.ID == id);
        }
    }
}
