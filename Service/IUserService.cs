using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> addUser(User user);
        Task<User> editUser(User userToUpdate);
        Task<User> getUser(string email, string password);
        //Task<User> getUserById(int id);
        //int checkPassword(string password);
    }
}