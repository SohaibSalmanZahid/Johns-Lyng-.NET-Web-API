namespace TodoList_Backend.DomainModel;

public class ToDoTask
{
    public Guid TaskId { get; set; }
    public string TaskDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    
    public Guid userId { get; set; }
}