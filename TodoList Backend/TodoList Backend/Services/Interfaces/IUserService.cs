using TodoList_Backend.DTOs.ResponseDTOs;

namespace TodoList_Backend.Services.Interfaces;

public interface IUserService
{
    List<UserResponseDTO> getAllUsers();
    
    UserResponseDTO addNewUser(string username);
  
}