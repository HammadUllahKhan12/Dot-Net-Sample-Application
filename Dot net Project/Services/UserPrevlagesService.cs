using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
  public  class UserPrevlagesService : IUserPrevlages
    {
        private readonly DataBaseContext _dbContext;
        public UserPrevlagesService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserPrevlages> GetUsersPrevlages()
        {
            return _dbContext.UserPrevlages.AsQueryable().ToList<UserPrevlages>();
        }
        public UserPrevlages GetUsersPrevlages(int id)
        {
            return _dbContext.UserPrevlages.Find(id);
        }

 
        public object PostUserPrevlage(UserPrevlages userprevlages)
        {
            _dbContext.UserPrevlages.Add(userprevlages);
            _dbContext.SaveChanges();

            return "Added Successfully!!!";
        }
    }
}
