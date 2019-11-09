using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
   public class UserService : IUserService 
    {
        private readonly DataBaseContext _dbContext;
        public UserService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.AsQueryable().ToList<User>();
        }
        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }
        public object PostUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return "Added Successfully!!!";
        }
        public bool UserExists(int id)
        {
            
            return _dbContext.Users.Any(e => e.UserId == id); 
        }
        public object PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return "Both Keys Are Different!!!";
            }

            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
               _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return "Invalid Key Enter!!!";
                }
                else
                {
                    throw;
                }
            }
            return "User Updated Successfully!!!";
        }
        public object DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return "NotFound !!!";
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return "Successfully Deleted!!!";
        }
        
    }
}