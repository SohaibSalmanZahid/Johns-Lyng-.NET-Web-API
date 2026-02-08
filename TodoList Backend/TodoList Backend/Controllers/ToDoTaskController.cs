using Microsoft.AspNetCore.Mvc;
using TodoList_Backend.DTOs.RequestDTOs;
using TodoList_Backend.DTOs.ResponseDTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoTaskController : Controller
{
    private readonly IToDoTaskService _toDoTaskService;
    private readonly ILogger<ToDoTaskController> _logger;
    
    public ToDoTaskController(IToDoTaskService taskService, ILogger<ToDoTaskController> logger)
    {
        _toDoTaskService = taskService;
        _logger = logger;
    }
    
    [HttpDelete("{taskId:guid}")]
    public IActionResult DeleteUserTask([FromRoute] Guid taskId)
    {
        _logger.LogInformation("DeleteUserTask called Controller");
        return Ok(_toDoTaskService.deleteUserTask(taskId));
    }
    
    [HttpPost]
    public IActionResult AddUserTask([FromBody] ToDoTaskRequestDTO task)
    {
        _logger.LogInformation("AddUserTask called Controller");
        ToDoTaskResponseDTO userTask = _toDoTaskService.addUserTask(task);
        return Ok(userTask);
    }

    [HttpGet("{userId:guid}")]
    public IActionResult GetAllUserTasks([FromRoute] Guid userId)
    {
        _logger.LogInformation("GetAllUserTasks called Controller");
        List<ToDoTaskResponseDTO> tasks = _toDoTaskService.getUserTasks(userId);
        return Ok(tasks);
    }
}