﻿using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        Task<CreateUser> CreateUser(CreateUser user);
        void DeleteUser(Guid? id);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();
        CreateUser ChangeAccess(Guid id, Access access);
        CreateUser EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password);
        Task<CreateUser> Authenticate(string username, string password);
    }
}
