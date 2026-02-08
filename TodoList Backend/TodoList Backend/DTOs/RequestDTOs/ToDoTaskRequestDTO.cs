using System.ComponentModel.DataAnnotations;

namespace TodoList_Backend.DTOs.RequestDTOs;

public class ToDoTaskRequestDTO
{
    [Required(ErrorMessage ="User ID is Required")]
    public Guid userId { get; set; }
    
    [Required(ErrorMessage = "Task Description is Required")]
    public string taskDescription { get; set; }
    
    [Required(ErrorMessage = "Creation Date is Required")]
    public DateOnly createdAt { get; set; }
    
    [Required(ErrorMessage = "Due Date is Required")]
    public DateOnly dueDate { get; set; }
}