using TodoList_Backend.DTOs;
using TodoList_Backend.DTOs.RequestDTOs;
using TodoList_Backend.DTOs.ResponseDTOs;

namespace TodoList_Backend.Services.Interfaces;

public interface IToDoTaskService
{
    List<ToDoTaskResponseDTO> getUserTasks(Guid userId);
    ToDoTaskResponseDTO addUserTask(ToDoTaskRequestDTO task);
    DeleteToDoTaskResponseDTO deleteUserTask(Guid taskId);
}