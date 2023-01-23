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


        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return  user;
        }


        public void DeleteUser(Guid? id)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();
        }

        public CreateUser GetOneUser(Guid id)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<CreateUser> GetUsers()
        {
            return _dbContext.User.ToList();
        }
        public CreateUser EditProfile(Guid id, string? firstName, string? lastName, string? email, string? password)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);
            user.FirstName = firstName == null ? user.FirstName : firstName;
            user.LastName = lastName == null ? user.LastName : lastName;
            user.Email = email == null ? user.Email : email;
            user.Password = password == null ? user.Password : password;
            _dbContext.SaveChanges();
            return user;
        }


        public async Task<CreateUser> Authenticate(string username, string password)
        {
            var user = _dbContext.User.SingleOrDefault(x => x.UserName == username && x.Password == password);
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
