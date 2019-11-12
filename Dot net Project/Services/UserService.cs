using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
   public class UserService : IUserService 
    {
        private readonly DataBaseContext databaseContext;
        public UserService(DataBaseContext dbContext)
        {
            databaseContext = dbContext;
        }

        public List<User> GetUsers()
        {
            return databaseContext.Users.AsQueryable().ToList<User>();
        }
        public User GetUser(int id)
        {
            return databaseContext.Users.Find(id);
        }
        public object PostUser(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();

            return "Added Successfully!!!";
        }
        public bool UserExists(int id)
        {
            
            return databaseContext.Users.Any(e => e.UserId == id); 
        }
        public object PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return "Both Keys Are Different!!!";
            }

            databaseContext.Entry(user).State = EntityState.Modified;
            try
            {
               databaseContext.SaveChanges();
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
            var user = databaseContext.Users.Find(id);
            if (user == null)
            {
                return "NotFound !!!";
            }

            databaseContext.Users.Remove(user);
            databaseContext.SaveChanges();

            return "Successfully Deleted!!!";
        }
        
    }
}