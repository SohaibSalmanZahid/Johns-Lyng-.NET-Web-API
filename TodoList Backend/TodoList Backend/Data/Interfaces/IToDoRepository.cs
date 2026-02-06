using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs;

namespace TodoList_Backend.Data.Interfaces;

public interface IToDoRepository
{
    public ToDoTask AddUserTask(ToDoTask userTask);
    public DeleteToDoTaskResponseDTO deleteTask(Guid taskId);
    public List<ToDoTask> getAllUserTasks(Guid userId);
}