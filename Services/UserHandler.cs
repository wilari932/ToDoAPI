using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public class UserHandler : IUserHandler
    {
        private readonly ToDoListDBContext _dbContext;
        public UserHandler(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<CreateUser> CreateUser(CreateUser user)         //Funkar
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }


        public async Task<CreateUser> DeleteUser (CreateUser user)
        {
            var deleteUser = _dbContext.User.FirstOrDefault(x => x.UserName == user.UserName);
            _dbContext.User.Remove(deleteUser);
            _dbContext.SaveChanges();
            return deleteUser;
        }

        public CreateUser GetOneUser(Guid id)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<CreateUser> GetUsers()                         //Funkar
        {
            return _dbContext.User.ToList();
        }


        public async Task<CreateUser> EditProfile(CreateUser user)    //Funkar
        {
            CreateUser theUser = _dbContext.User.FirstOrDefault(x => x.UserName == user.UserName);
            theUser.FirstName = user.FirstName ?? theUser.FirstName;
            theUser.LastName = user.LastName ?? theUser.LastName;
            theUser.Email = user.Email ?? theUser.Email;
            theUser.Password = user.Password ?? theUser.FirstName;
            theUser.UserName = user.UserName ?? theUser.UserName;
            _dbContext.SaveChanges();
            return user;
        }


        public async Task<CreateUser> Authenticate(string username, string password)         //Funkar
        {
            var user = _dbContext.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
            UserDictionary.userId["UserId"] = user.Id.ToString();  //Funkar
            return user;
        }

        public CreateUser ChangeAccess(Guid id, Access access)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            user.Access = access;
            _dbContext.SaveChanges();
            return user;
        }




    }
}
