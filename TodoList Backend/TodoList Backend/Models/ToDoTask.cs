namespace TodoList_Backend.DomainModel;

public class ToDoTask
{
    public Guid TaskId { get; set; }
    public string TaskDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
}