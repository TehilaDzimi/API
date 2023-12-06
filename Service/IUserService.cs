using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> addUser(User user);
        Task<User> editUser(User userToUpdate);
        Task<User> getUser(string email, string password);
 
    }
}