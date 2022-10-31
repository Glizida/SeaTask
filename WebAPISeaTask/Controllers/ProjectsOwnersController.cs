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
    public class ProjectsOwnersController : ControllerBase
    {
        private readonly master_bdContext _context;

        public ProjectsOwnersController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/ProjectsOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsOwner>>> GetProjectsOwners()
        {
            return await _context.ProjectsOwners.ToListAsync();
        }

        // GET: api/ProjectsOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectsOwner>> GetProjectsOwner(int id)
        {
            var projectsOwner = await _context.ProjectsOwners.FindAsync(id);

            if (projectsOwner == null)
            {
                return NotFound();
            }

            return projectsOwner;
        }

        // PUT: api/ProjectsOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectsOwner(int id, ProjectsOwner projectsOwner)
        {
            if (id != projectsOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectsOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsOwnerExists(id))
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

        // POST: api/ProjectsOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectsOwner>> PostProjectsOwner(ProjectsOwner projectsOwner)
        {
            _context.ProjectsOwners.Add(projectsOwner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectsOwnerExists(projectsOwner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjectsOwner", new { id = projectsOwner.Id }, projectsOwner);
        }

        // DELETE: api/ProjectsOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectsOwner(int id)
        {
            var projectsOwner = await _context.ProjectsOwners.FindAsync(id);
            if (projectsOwner == null)
            {
                return NotFound();
            }

            _context.ProjectsOwners.Remove(projectsOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectsOwnerExists(int id)
        {
            return _context.ProjectsOwners.Any(e => e.Id == id);
        }
    }
}
