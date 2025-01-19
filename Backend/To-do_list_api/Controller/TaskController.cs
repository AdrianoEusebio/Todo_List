using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;
    public TaskController(AppDbContext context)
    {
        _context = context;
    }   

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
    {
        var taskItem = await _context.TaskItems.FindAsync(id);

        if (taskItem == null)
        {
            return NotFound();
        }

        return taskItem;
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
    {
        _context.TaskItems.Add(taskItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTaskItem(long id, TaskItem taskItem)
    {
        if (id != taskItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(taskItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskItem(long id)
    {
        var taskItem = await _context.TaskItems.FindAsync(id);

        if (taskItem == null)
        {
            return NotFound();
        }

        _context.TaskItems.Remove(taskItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}