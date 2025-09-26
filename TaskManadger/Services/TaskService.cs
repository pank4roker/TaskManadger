using TaskManadger.DTO;
using TaskManadger.Infrastructure;
using TaskManadger.Models;
using TaskManadger.Services;

namespace TodoApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

    public TaskService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<TaskDto> GetAll()
    {
        return  _dbContext.TaskItems
            .Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            })
            .ToList();
    }

    public TaskDto GetById(int id)
    {
        var task = _dbContext.TaskItems.Find(id);
        if (task == null) return null;

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskDto Create(CreateTaskDto newTask)
    {
        var task = new TaskItem
        {
            Title = newTask.Title,
            Description = newTask.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.TaskItems.Add(task);
        _dbContext.SaveChanges();

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskDto Update(int id, UpdateTaskDto updatedTask)
    {
        var task = _dbContext.TaskItems.Find(id);
        if (task == null) return null;

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        _dbContext.SaveChanges();

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };
    }

    public bool Delete(int id)
    {
        var task = _dbContext.TaskItems.Find(id);
        if (task == null) return false;

        _dbContext.TaskItems.Remove(task);
        _dbContext.SaveChanges();
        return true;
    }
    }
}
