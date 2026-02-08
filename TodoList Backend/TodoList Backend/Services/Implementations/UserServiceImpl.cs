using System.Text.Json;
using TodoList_Backend.Data;
using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs.RequestDTOs;
using TodoList_Backend.DTOs.ResponseDTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Services.Implementations;

public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserServiceImpl> _logger;
    
    public  UserServiceImpl(IUserRepository userRepository, ILogger<UserServiceImpl> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    public List<UserResponseDTO> getAllUsers()
    {
        _logger.Log(LogLevel.Information, "GetAllUsers called Service");
        
        List<UserResponseDTO> users = new List<UserResponseDTO>();
        try
        {
            List<User> userList = _userRepository.getAllUsers();
            if (!userList.Any())
            {
                throw new Exception("No Users Found");
            }
            for (int i = 0; i < userList.Count; i++)
            {
                UserResponseDTO user = new UserResponseDTO();
                user.userId = userList[i].UserId;
                user.userName = userList[i].Username;
                users.Add(user);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return users;
    }

    public UserResponseDTO addNewUser(UserRequestDTO userRequest)
    {
        _logger.Log(LogLevel.Information, "AddNewUser called Service, user: " + JsonSerializer.Serialize(userRequest));
        
        UserResponseDTO user = new UserResponseDTO();
        
        try
        {
            User newUser = new User();
            newUser.Username = userRequest.name;
            newUser = _userRepository.addNewUser(newUser);
            user.userId = newUser.UserId;
            user.userName = newUser.Username;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return user;
    }
}