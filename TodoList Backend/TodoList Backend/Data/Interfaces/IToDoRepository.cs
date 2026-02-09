using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs;

namespace TodoList_Backend.Data.Interfaces;

public interface IToDoRepository
{
    ToDoTask AddUserTask(ToDoTask userTask);
    DeleteToDoTaskResponseDTO deleteTask(Guid taskId);
    List<ToDoTask> getAllUserTasks(Guid userId);
    bool getUserTaskByTaskId(Guid taskId);
}