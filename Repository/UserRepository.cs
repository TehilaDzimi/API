using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyShop910Context DB_contect;
        public UserRepository(MyShop910Context DBcontect)
        {
            DB_contect = DBcontect;
        }
        public async Task<User> addUser(User user)
        {
            await DB_contect.Users.AddAsync(user);
            await DB_contect.SaveChangesAsync();
            return user;

        }

        public async Task<User> getUser(string email, string password)
        {
            return await DB_contect.Users.Where(i => i.Email == email && i.Password == password).Include(i=>i.Orders).FirstOrDefaultAsync();
        }

        public async Task<User> editUser(User userToUpdate)
        {
            DB_contect.Users.Update(userToUpdate);
            await DB_contect.SaveChangesAsync();
            return userToUpdate;
        }
    }
}