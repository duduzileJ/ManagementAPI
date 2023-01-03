using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagementAPI.Data;
using ManagementAPI.Models;
using Microsoft.AspNet.OData;

namespace ManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsViewController : Controller
    {
        
        private readonly ManagementDb _context;
        public EmployeeDetailsViewController(ManagementDb context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetailsView
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetailsViewModel>>> GetEmployeeDetailViewModels()
        {
            //var employee = _context.EmployeeDetailViewModels.AsQueryable();
            //var result = employee.AsQueryable().ApplyODataQuery(Request);

            return await _context.EmployeeDetailViewModels.ToListAsync();
        }

        // GET: api/EmployeeDetailsView/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailsViewModel>> GetEmployeeDetailsViewModel(int id)
        {
            var employeeDetailsViewModel = await _context.EmployeeDetailViewModels.FindAsync(id);

            if (employeeDetailsViewModel == null)
            {
                return NotFound();
            }

            return employeeDetailsViewModel;
        }

        // PUT: api/EmployeeDetailsView/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetailsViewModel(int id, EmployeeDetailsViewModel employeeDetailsViewModel)
        {
            if (id != employeeDetailsViewModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetailsViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsViewModelExists(id))
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

        // POST: api/EmployeeDetailsView
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDetailsViewModel>> PostEmployeeDetailsViewModel(EmployeeDetailsViewModel employeeDetailsViewModel)
        {
            _context.EmployeeDetailViewModels.Add(employeeDetailsViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetailsViewModel", new { id = employeeDetailsViewModel.ID }, employeeDetailsViewModel);
        }

        // DELETE: api/EmployeeDetailsView/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetailsViewModel(int id)
        {
            var employeeDetailsViewModel = await _context.EmployeeDetailViewModels.FindAsync(id);
            if (employeeDetailsViewModel == null)
            {
                return NotFound();
            }

            _context.EmployeeDetailViewModels.Remove(employeeDetailsViewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDetailsViewModelExists(int id)
        {
            return _context.EmployeeDetailViewModels.Any(e => e.ID == id);
        }
    }
}
