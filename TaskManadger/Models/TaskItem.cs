namespace TaskManadger.Models;

public class TaskItem
{
    public int Id { get; set; }              // ID задачи
    public string Title { get; set; }        // Заголовок
    public string Description { get; set; }  // Описание
    public bool IsCompleted { get; set; }    // Статус выполнения
    public DateTime CreatedAt { get; set; }  // Дата создания
}