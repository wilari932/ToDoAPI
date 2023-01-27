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


        public CreateUser CreateUser(CreateUser user)         //Funkar
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }


        public CreateUser DeleteUser (CreateUser user)
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


        public CreateUser EditProfile(CreateUser user)    //Funkar
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


        public CreateUser Authenticate(CreateUser user)        //Funkar 
        {
            var theUser = _dbContext.User.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            UserDictionary.userId["UserId"] = theUser.Id.ToString(); 
            return theUser;
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
