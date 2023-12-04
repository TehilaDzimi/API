using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyShop8910Context DB_contect;
        public UserRepository(MyShop8910Context DBcontect)
        {
            DB_contect = DBcontect;
        }
        //string path = "M:/WebApi/NewWebApi/ApiEx01/API/wwwroot/users.txt";
        public async Task<User> addUser(User user)
        {
            await DB_contect.Users.AddAsync(user);
            await DB_contect.SaveChangesAsync();
            //int numberOfUsers =  System.IO.File.ReadLines(path).Count();
            //user.UserId = numberOfUsers + 1;
            ////var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            ////if (result.Score <= 2)
            ////{
            ////    return BadRequest();
            ////}
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;

        }

        public async Task<User> getUser(string email, string password)
        {
            return await DB_contect.Users.Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();

            //using (StreamReader reader =  System.IO.File.OpenText(path))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.Email == userName && user.Password == password)
            //            return user;
            //    }
            //}
            //return null;
        }

        public async Task<User> editUser(User userToUpdate)
        {
            DB_contect.Users.Update(userToUpdate);
            await DB_contect.SaveChangesAsync();
            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile =await reader.ReadLineAsync()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == userToUpdate.UserId)
            //            textToReplace = currentUserInFile; 
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText(path);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            //    System.IO.File.WriteAllText(path, text);
            //}


            return userToUpdate;
        }

        //public async Task<User> getUserById(int id)
        //{


        //    using (StreamReader reader = System.IO.File.OpenText(path))
        //    {
        //        string? currentUserInFile;
        //        while ((currentUserInFile = await reader.ReadLineAsync()) != null)
        //        {
        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.UserId == id)
        //                return user;
        //        }
        //    }
        //    return null;
        //}
    }
}