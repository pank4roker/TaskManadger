using TaskManadger.DTO;

namespace TaskManadger.Services;

public interface ITaskService
{
    IEnumerable<TaskDto> GetAll();
    TaskDto GetById(int id);
    TaskDto Create(CreateTaskDto newTask);
    TaskDto Update(int id, UpdateTaskDto updatedTask);
    bool Delete(int id);
}