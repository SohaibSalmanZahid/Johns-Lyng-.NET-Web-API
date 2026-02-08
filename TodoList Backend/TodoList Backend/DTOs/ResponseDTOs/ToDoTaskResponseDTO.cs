namespace TodoList_Backend.DTOs.ResponseDTOs;

public class ToDoTaskResponseDTO
{
    public Guid taskId { get; set; }
    public Guid userId { get; set; }
    public string taskDescription { get; set; }
    public DateOnly createdAt { get; set; }
    public DateOnly dueDate { get; set; }
}