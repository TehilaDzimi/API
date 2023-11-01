using Entities;

namespace Service
{
    public interface IUserService
    {
        User addUser(User user);
        Task<User> editUser(User userToUpdate);
        Task<User> getUser(string userName, string password);
        Task<User> getUserById(int id);
        //int checkPassword(string password);
    }
}