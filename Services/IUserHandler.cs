using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserHandler
    {
        CreateUser CreateUser(CreateUser user); //Funkar
        CreateUser DeleteUser(CreateUser user);
        CreateUser GetOneUser(Guid id);
        IEnumerable<CreateUser> GetUsers();
        CreateUser ChangeAccess(Guid id, Access access);

        CreateUser EditProfile(CreateUser user);    //Funkar
        CreateUser Authenticate(CreateUser user);     //Funkar
    }
}
