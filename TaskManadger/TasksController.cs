using TaskManadger.DTO;
using TaskManadger.Models;
using TaskManadger.Services;

namespace TaskManadger;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET /tasks
    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _taskService.GetAll();
        return Ok(tasks);
    }

    // POST /tasks
    [HttpPost]
    public IActionResult Create([FromBody] CreateTaskDto task)
    {
        var created = _taskService.Create(task);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // GET /tasks/{id} (для CreatedAtAction)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var task = _taskService.GetById(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    // PUT /tasks/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateTaskDto task)
    {
        var updated = _taskService.Update(id, task);
        if (updated==null) return NotFound();
        return NoContent();
    }

    // DELETE /tasks/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _taskService.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
