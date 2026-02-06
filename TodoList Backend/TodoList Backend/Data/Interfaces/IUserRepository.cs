using TodoList_Backend.DomainModel;

namespace TodoList_Backend.Data.Interfaces;

public interface IUserRepository
{
    User addNewUser(User newUser);
    List<User> getAllUsers();
}