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
    public class TypeTasksController : ControllerBase
    {
        private readonly master_bdContext _context;

        public TypeTasksController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/TypeTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeTask>>> GetTypeTasks()
        {
            return await _context.TypeTasks.ToListAsync();
        }

        // GET: api/TypeTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeTask>> GetTypeTask(int id)
        {
            var typeTask = await _context.TypeTasks.FindAsync(id);

            if (typeTask == null)
            {
                return NotFound();
            }

            return typeTask;
        }

        // PUT: api/TypeTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeTask(int id, TypeTask typeTask)
        {
            if (id != typeTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeTaskExists(id))
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

        // POST: api/TypeTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeTask>> PostTypeTask(TypeTask typeTask)
        {
            _context.TypeTasks.Add(typeTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeTaskExists(typeTask.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeTask", new { id = typeTask.Id }, typeTask);
        }

        // DELETE: api/TypeTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeTask(int id)
        {
            var typeTask = await _context.TypeTasks.FindAsync(id);
            if (typeTask == null)
            {
                return NotFound();
            }

            _context.TypeTasks.Remove(typeTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeTaskExists(int id)
        {
            return _context.TypeTasks.Any(e => e.Id == id);
        }
    }
}
