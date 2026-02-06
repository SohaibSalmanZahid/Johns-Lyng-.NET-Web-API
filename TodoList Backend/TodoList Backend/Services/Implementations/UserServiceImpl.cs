using TodoList_Backend.Data;
using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.DomainModel;
using TodoList_Backend.DTOs.ResponseDTOs;
using TodoList_Backend.Services.Interfaces;

namespace TodoList_Backend.Services.Implementations;

public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public  UserServiceImpl(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public List<UserResponseDTO> getAllUsers()
    {
        List<UserResponseDTO> users = new List<UserResponseDTO>();
        try
        {
            List<User> userList = _userRepository.getAllUsers();
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
            Console.WriteLine(e);
            throw;
        }

        return users;
    }

    public UserResponseDTO addNewUser(string username)
    {
        UserResponseDTO user = new UserResponseDTO();
        
        try
        {
            User newUser = new User();
            newUser.Username = username;
            newUser = _userRepository.addNewUser(newUser);
            user.userId = newUser.UserId;
            user.userName = newUser.Username;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return user;
    }
}