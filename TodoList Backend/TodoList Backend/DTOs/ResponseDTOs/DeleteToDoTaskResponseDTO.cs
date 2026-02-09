using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs.ResponseDTOs;

namespace TodoList_Backend.DTOs;

public class DeleteToDoTaskResponseDTO
{
    public string message { get; set; }
    public Guid todoTaskId { get; set; }
    
    public DeleteToDoTaskResponseDTO()
    {
    }

    public DeleteToDoTaskResponseDTO(string message, Guid todoTaskId)
    {
        this.message = message;
        this.todoTaskId = todoTaskId;
    }

}