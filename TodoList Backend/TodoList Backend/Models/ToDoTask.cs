namespace TodoList_Backend.DomainModel;

public class ToDoTask
{
    public Guid TaskId { get; set; }
    public string TaskDescription { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly DueDate { get; set; }
    
    public Guid userId { get; set; }
}