using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
  public  class PrivilegeService : IPrevlages
    {
        private readonly DataBaseContext _dbContext;
        public PrivilegeService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Privilege> GetUsersPrevlages()
        {
            return _dbContext.Prevlages.AsQueryable().ToList<Privilege>();
        }
        public Privilege GetUsersPrevlages(int id)
        {
            return _dbContext.Prevlages.Find(id);
        } 
        public object PostUserPrevlage(Privilege userprevlages)
        {
            userprevlages.RolePrivilege = null;
            _dbContext.Prevlages.Add(userprevlages);
            _dbContext.SaveChanges();
            return "Added Successfully!!!";
        }
    }
}
