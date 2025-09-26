namespace TaskManadger.DTO;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

public class CreateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class UpdateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}