namespace TodoList_Backend.DTOs.RequestDTOs;

public class ToDoTaskRequestDTO
{
    public Guid userId { get; set; }
    public string taskDescription { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime dueDate { get; set; }
}