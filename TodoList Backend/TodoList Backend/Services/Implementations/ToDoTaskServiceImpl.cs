using Microsoft.AspNetCore.Http.HttpResults;
using TodoList_Backend.Data;
using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs;
using TodoList_Backend.DTOs.RequestDTOs;
using TodoList_Backend.DTOs.ResponseDTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Services.Implementations;

public class ToDoTaskServiceImpl:IToDoTaskService
{
    private readonly IToDoRepository _todoRepository;
    private readonly ILogger<ToDoTaskServiceImpl> _logger;
    
    public ToDoTaskServiceImpl(IToDoRepository todoRepository, ILogger<ToDoTaskServiceImpl> logger)
    {
        _todoRepository = todoRepository;
        _logger = logger;
    }
    
    public List<ToDoTaskResponseDTO> getUserTasks(Guid userId)
    {
        _logger.Log(LogLevel.Information, "GetUserTasks called Service");
        List<ToDoTaskResponseDTO> userTasks = new List<ToDoTaskResponseDTO>();
        try
        {
            List<ToDoTask> users = _todoRepository.getAllUserTasks(userId);
            for (int i = 0; i < users.Count; i++)
            {
                ToDoTaskResponseDTO task = new ToDoTaskResponseDTO();
                task.userId = users[i].userId;
                task.todoTaskId = users[i].TaskId;
                task.createdAt = users[i].CreatedAt;
                task.dueDate = users[i].DueDate;
                task.taskDescription = users[i].TaskDescription;
                userTasks.Add(task);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return userTasks;
    }

    public ToDoTaskResponseDTO addUserTask(ToDoTaskRequestDTO task)
    {
        ToDoTaskResponseDTO response = new ToDoTaskResponseDTO();
        try
        {
            ToDoTask toDoTask = new ToDoTask();
            toDoTask.userId = task.userId;
            toDoTask.CreatedAt = task.createdAt;
            toDoTask.DueDate = task.dueDate;
            toDoTask.TaskDescription = task.taskDescription;
            toDoTask = _todoRepository.AddUserTask(toDoTask);
            response.userId = toDoTask.userId;
            response.createdAt = toDoTask.CreatedAt;
            response.dueDate = toDoTask.DueDate;
            response.taskDescription = toDoTask.TaskDescription;
            response.todoTaskId = toDoTask.TaskId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return response;
    }

    public DeleteToDoTaskResponseDTO deleteUserTask(Guid taskId)
    {
        try
        {
            _todoRepository.deleteTask(taskId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return new DeleteToDoTaskResponseDTO(200, "Deleted Successfully",  taskId);
    }
}