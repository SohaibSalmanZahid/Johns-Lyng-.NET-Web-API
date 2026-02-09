using System.Text.Json;
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
    private readonly IUserRepository _userRepository;
    private readonly ILogger<ToDoTaskServiceImpl> _logger;
    
    public ToDoTaskServiceImpl(IToDoRepository todoRepository, ILogger<ToDoTaskServiceImpl> logger, IUserRepository userRepository)
    {
        _todoRepository = todoRepository;
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public List<ToDoTaskResponseDTO> getUserTasks(Guid userId)
    {
        _logger.Log(LogLevel.Information, "GetUserTasks called Service, user id: " + userId);

        if (userId == Guid.Empty)
        {
            _logger.LogWarning("User Id cannot be empty");
            throw new ArgumentException("UserId cannot be empty");
        }
        
        List<ToDoTaskResponseDTO> userTasks = new List<ToDoTaskResponseDTO>();
        try
        {
            List<ToDoTask> allUserTasks = _todoRepository.getAllUserTasks(userId);
            if (!allUserTasks.Any())
            {
                _logger.LogWarning("No Tasks Found for the user with id: " + userId);
            }
            for (int i = 0; i < allUserTasks.Count; i++)
            {
                ToDoTaskResponseDTO task = new ToDoTaskResponseDTO();
                task.userId = allUserTasks[i].userId;
                task.taskId = allUserTasks[i].TaskId;
                task.createdAt = allUserTasks[i].CreatedAt;
                task.dueDate = allUserTasks[i].DueDate;
                task.taskDescription = allUserTasks[i].TaskDescription;
                userTasks.Add(task);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        return userTasks;
    }

    public ToDoTaskResponseDTO addUserTask(ToDoTaskRequestDTO task)
    {
        _logger.Log(LogLevel.Information, "AddUserTask called Service, task: " + JsonSerializer.Serialize(task));
        
        ToDoTaskResponseDTO response = new ToDoTaskResponseDTO();
        try
        {
            if (_userRepository.getUserById(task.userId) == null)
            {
                _logger.LogWarning("User with id: " + task.userId + " not found");
                throw new KeyNotFoundException("User with id: " + task.userId + " not found");
            }
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
            response.taskId = toDoTask.TaskId;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        return response;
    }

    public DeleteToDoTaskResponseDTO deleteUserTask(Guid taskId)
    {
        _logger.Log(LogLevel.Information, "DeleteUserTask called Service, taskId: " + taskId);
        try
        {
            if (taskId == Guid.Empty)
            {
                _logger.LogWarning("Task Id cannot be empty");
                throw new ArgumentException("Task Id cannot be empty");
            }

            if (!_todoRepository.getUserTaskByTaskId(taskId))
            {
                _logger.LogWarning("User with id: " + taskId + " not found");
                throw new KeyNotFoundException("User with id: " + taskId + " not found");
            }
            _todoRepository.deleteTask(taskId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        
        return new DeleteToDoTaskResponseDTO("Deleted Successfully",  taskId);
    }
}