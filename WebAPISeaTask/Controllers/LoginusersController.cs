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
    public class LoginusersController : ControllerBase
    {
        private readonly master_bdContext _context;

        public LoginusersController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/Loginusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loginuser>>> GetLoginusers()
        {
            return await _context.Loginusers.ToListAsync();
        }

        // GET: api/Loginusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loginuser>> GetLoginuser(int id)
        {
            var loginuser = await _context.Loginusers.FindAsync(id);

            if (loginuser == null)
            {
                return NotFound();
            }

            return loginuser;
        }

        // PUT: api/Loginusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginuser(int id, Loginuser loginuser)
        {
            if (id != loginuser.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginuserExists(id))
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

        // POST: api/Loginusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loginuser>> PostLoginuser(Loginuser loginuser)
        {
            _context.Loginusers.Add(loginuser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginuserExists(loginuser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginuser", new { id = loginuser.Id }, loginuser);
        }

        // DELETE: api/Loginusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginuser(int id)
        {
            var loginuser = await _context.Loginusers.FindAsync(id);
            if (loginuser == null)
            {
                return NotFound();
            }

            _context.Loginusers.Remove(loginuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginuserExists(int id)
        {
            return _context.Loginusers.Any(e => e.Id == id);
        }
    }
}
