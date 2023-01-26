using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        Task<CreateUser> CreateUser(CreateUser user); //Funkar
        Task <CreateUser> DeleteUser(CreateUser user);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();
        CreateUser ChangeAccess(Guid id, Access access);

        Task<CreateUser> EditProfile(CreateUser user);    //Funkar
        Task<CreateUser> Authenticate(string username, string password);     //Funkar
    }
}
