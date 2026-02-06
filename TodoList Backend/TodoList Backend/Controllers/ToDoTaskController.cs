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
    
    public ToDoTaskController(IToDoTaskService taskService)
    {
        _toDoTaskService = taskService;
    }
    
    [HttpDelete("{taskId:guid}")]
    public IActionResult DeleteUserTask([FromRoute] Guid taskId)
    {
        return Ok(_toDoTaskService.deleteUserTask(taskId));
    }
    
    [HttpPost]
    public IActionResult AddUserTask([FromBody] ToDoTaskRequestDTO task)
    {
        ToDoTaskResponseDTO userTask = _toDoTaskService.addUserTask(task);
        return Ok(userTask);
    }

    [HttpGet("{userId:guid}")]
    public IActionResult GetAllUserTasks([FromRoute] Guid userId)
    {
        List<ToDoTaskResponseDTO> tasks = _toDoTaskService.getUserTasks(userId);
        return Ok(tasks);
    }
}