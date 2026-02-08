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
        for (int i = 0; i < todoTasks.Count; i++)
        {
            if (todoTasks[i].userId == userId)
            {
                userTasks.Add(todoTasks[i]);
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
        for (int i = 0; i < todoTasks.Count; i++)
        {
            if (todoTasks[i].TaskId == taskId)
            {
                todoTasks.RemoveAt(i);
            }
        }
        return new DeleteToDoTaskResponseDTO();
    }

    public bool getUserTaskByTaskId(Guid taskId)
    {
        for (int i = 0; i < todoTasks.Count; i++)
        {
            if (todoTasks[i].TaskId == taskId)
            {
                return true;
            }
        }
        
        return false;
    }
}