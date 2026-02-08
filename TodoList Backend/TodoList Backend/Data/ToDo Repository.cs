using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Data;

public class ToDo_Repository : IToDoRepository
{
    private readonly IToDoRepository _todoRepository;
    
    public List<ToDoTask> todoTasks = new List<ToDoTask>();

    public List<ToDoTask> getAllUserTasks(Guid userId)
    {
        List<ToDoTask> userTasks = new List<ToDoTask>();

        foreach (var todo in todoTasks)
        {
            if (todo.userId == userId)
            {
                userTasks.Add(todo);
            }
        }
        return userTasks;
    }

    public ToDoTask AddUserTask(ToDoTask userTask)
    {
        userTask.TaskId = Guid.NewGuid();
        todoTasks.Add(userTask);
        return userTask;
    }

    public DeleteToDoTaskResponseDTO deleteTask(Guid taskId)
    {
        foreach (var todo in todoTasks)
        {
            if (todo.TaskId == taskId)
            {
                todoTasks.Remove(todo);
                break;
            }
        }
       
        return new DeleteToDoTaskResponseDTO();
    }

    public bool getUserTaskByTaskId(Guid taskId)
    {
        foreach (var todo in todoTasks)
        {
            if (todo.TaskId == taskId)
            {
                return true;
            }
        }
        
        return false;
    }
}