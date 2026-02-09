using Microsoft.AspNetCore.Identity;
using TodoList_Backend.Data.Interfaces;
using TodoList_Backend.DomainModel;

namespace TodoList_Backend.Data;

public class UserRepository : IUserRepository
{
    
    public List<User> users = new List<User>();

    public User addNewUser(User newUser)
    {

        newUser.UserId = Guid.NewGuid();
        users.Add(newUser);
        return newUser;
    }

    public List<User> getAllUsers()
    {
        return users;
    }

    public User? getUserById(Guid userId)
    {
        foreach (var user in users)
        {
            if (user.UserId == userId)
            {
                return user;
            }
        }
        return null;
    }
}