﻿using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User addUser(User user);
        Task<User> editUser(User userToUpdate);
        Task<User> getUser(string userName, string password);
        Task<User> getUserById(int id);
    }
}