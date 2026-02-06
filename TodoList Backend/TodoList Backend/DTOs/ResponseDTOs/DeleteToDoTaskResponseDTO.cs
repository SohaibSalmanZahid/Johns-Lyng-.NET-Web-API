using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs.ResponseDTOs;

namespace TodoList_Backend.DTOs;

public class DeleteToDoTaskResponseDTO
{
    public DeleteToDoTaskResponseDTO()
    {
    }

    public DeleteToDoTaskResponseDTO(int statusCode, string message, Guid todoTaskId)
    {
        this.statusCode = statusCode;
        this.message = message;
        this.todoTaskId = todoTaskId;
    }

    public int  statusCode { get; set; }
    public string message { get; set; }
    public Guid todoTaskId { get; set; }
}