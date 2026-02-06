namespace TodoList_Backend.DTOs.ResponseDTOs;

public class ToDoTaskResponseDTO
{
    public Guid todoTaskId { get; set; }
    public Guid userId { get; set; }
    public string taskDescription { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime dueDate { get; set; }
}