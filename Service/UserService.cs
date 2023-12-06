using Entities;
using Repository;

namespace Service
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository u)
        {
            userRepository = u;
        }


        public async Task<User> addUser(User user)
        {
            if (checkPassword(user.Password) < 2)
            {
                return null;
            }
            return await userRepository.addUser(user);
        }



        public async Task<User> getUser(string email, string password)
        {
            return await userRepository.getUser(email, password);
        }


        public async Task<User> editUser(User userToUpdate)
        {

            return await userRepository.editUser(userToUpdate);
        }

        private int checkPassword(string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;
        }
    }
}