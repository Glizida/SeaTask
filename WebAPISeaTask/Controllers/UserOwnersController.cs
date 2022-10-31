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
    public class UserOwnersController : ControllerBase
    {
        private readonly master_bdContext _context;

        public UserOwnersController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/UserOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOwner>>> GetUserOwners()
        {
            return await _context.UserOwners.ToListAsync();
        }

        // GET: api/UserOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOwner>> GetUserOwner(int id)
        {
            var userOwner = await _context.UserOwners.FindAsync(id);

            if (userOwner == null)
            {
                return NotFound();
            }

            return userOwner;
        }

        // PUT: api/UserOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOwner(int id, UserOwner userOwner)
        {
            if (id != userOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(userOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOwnerExists(id))
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

        // POST: api/UserOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOwner>> PostUserOwner(UserOwner userOwner)
        {
            _context.UserOwners.Add(userOwner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserOwnerExists(userOwner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserOwner", new { id = userOwner.Id }, userOwner);
        }

        // DELETE: api/UserOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOwner(int id)
        {
            var userOwner = await _context.UserOwners.FindAsync(id);
            if (userOwner == null)
            {
                return NotFound();
            }

            _context.UserOwners.Remove(userOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserOwnerExists(int id)
        {
            return _context.UserOwners.Any(e => e.Id == id);
        }
    }
}
