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
    public class FilesTasksController : ControllerBase
    {
        private readonly master_bdContext _context;

        public FilesTasksController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/FilesTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilesTask>>> GetFilesTasks()
        {
            return await _context.FilesTasks.ToListAsync();
        }

        // GET: api/FilesTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilesTask>> GetFilesTask(int id)
        {
            var filesTask = await _context.FilesTasks.FindAsync(id);

            if (filesTask == null)
            {
                return NotFound();
            }

            return filesTask;
        }

        // PUT: api/FilesTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilesTask(int id, FilesTask filesTask)
        {
            if (id != filesTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(filesTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilesTaskExists(id))
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

        // POST: api/FilesTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilesTask>> PostFilesTask(FilesTask filesTask)
        {
            _context.FilesTasks.Add(filesTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilesTaskExists(filesTask.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilesTask", new { id = filesTask.Id }, filesTask);
        }

        // DELETE: api/FilesTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilesTask(int id)
        {
            var filesTask = await _context.FilesTasks.FindAsync(id);
            if (filesTask == null)
            {
                return NotFound();
            }

            _context.FilesTasks.Remove(filesTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilesTaskExists(int id)
        {
            return _context.FilesTasks.Any(e => e.Id == id);
        }
    }
}
