using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        CreateUser CreateUser(string FirstName, string LastName, string UserName, string Email, string Password);
        void DeleteUser(Guid id);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();

        CreateUser EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password);

        Task<CreateUser> Authenticate(string username, string password);
    }
}
