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
    public class TasksUsersController : ControllerBase
    {
        private readonly master_bdContext _context;

        public TasksUsersController(master_bdContext context)
        {
            _context = context;
        }

        // GET: api/TasksUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksUser>>> GetTasksUsers()
        {
            return await _context.TasksUsers.ToListAsync();
        }

        // GET: api/TasksUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TasksUser>> GetTasksUser(int id)
        {
            var tasksUser = await _context.TasksUsers.FindAsync(id);

            if (tasksUser == null)
            {
                return NotFound();
            }

            return tasksUser;
        }

        // PUT: api/TasksUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasksUser(int id, TasksUser tasksUser)
        {
            if (id != tasksUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasksUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksUserExists(id))
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

        // POST: api/TasksUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TasksUser>> PostTasksUser(TasksUser tasksUser)
        {
            _context.TasksUsers.Add(tasksUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TasksUserExists(tasksUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTasksUser", new { id = tasksUser.Id }, tasksUser);
        }

        // DELETE: api/TasksUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasksUser(int id)
        {
            var tasksUser = await _context.TasksUsers.FindAsync(id);
            if (tasksUser == null)
            {
                return NotFound();
            }

            _context.TasksUsers.Remove(tasksUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TasksUserExists(int id)
        {
            return _context.TasksUsers.Any(e => e.Id == id);
        }
    }
}
