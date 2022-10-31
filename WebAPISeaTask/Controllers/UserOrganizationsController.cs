using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISeaTask;
using WebAPISeaTask.ClassBD;

namespace WebAPISeaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrganizationsController : ControllerBase
    {
        private readonly master_bdContext _context;

        public UserOrganizationsController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/UserOrganizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOrganization>>> GetUserOrganizations()
        {
            return await _context.UserOrganizations.ToListAsync();
        }

        // GET: api/UserOrganizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOrganization>> GetUserOrganization(int id)
        {
            var userOrganization = await _context.UserOrganizations.FindAsync(id);

            if (userOrganization == null)
            {
                return NotFound();
            }

            return userOrganization;
        }

        // PUT: api/UserOrganizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOrganization(int id, UserOrganization userOrganization)
        {
            if (id != userOrganization.Id)
            {
                return BadRequest();
            }

            _context.Entry(userOrganization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOrganizationExists(id))
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

        // POST: api/UserOrganizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOrganization>> PostUserOrganization(UserOrganization userOrganization)
        {
            _context.UserOrganizations.Add(userOrganization);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserOrganizationExists(userOrganization.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserOrganization", new { id = userOrganization.Id }, userOrganization);
        }

        // DELETE: api/UserOrganizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOrganization(int id)
        {
            var userOrganization = await _context.UserOrganizations.FindAsync(id);
            if (userOrganization == null)
            {
                return NotFound();
            }

            _context.UserOrganizations.Remove(userOrganization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserOrganizationExists(int id)
        {
            return _context.UserOrganizations.Any(e => e.Id == id);
        }
    }
}
