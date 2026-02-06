using Microsoft.AspNetCore.Mvc;
using TodoList_Backend.DTOs.ResponseDTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    
    private readonly IUserService _userService;
    
    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        _logger.LogInformation("Getting All Users Controller");
        List<UserResponseDTO> users = new List<UserResponseDTO>();
        users = _userService.getAllUsers();
        return Ok(users);
    }

    [HttpPost("{username}")]
    public IActionResult AddNewUser([FromRoute] String username)
    {
        return Ok(_userService.addNewUser(username));
    }

   
}