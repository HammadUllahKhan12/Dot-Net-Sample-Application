using Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class RoleService : IRoleServices
    {
        private readonly DataBaseContext dataBaseContext;

        public RoleService ( DataBaseContext context)
        {
            dataBaseContext = context;
        }
        public List<Role> GetRoles()
        {
         return dataBaseContext.Roles.AsQueryable().ToList<Role>();     
        }
        public Role GetRole(int id)
        {

            return dataBaseContext.Roles.Find(id);
        }
        public object PostRole(Role role)
        {
            dataBaseContext.Roles.Add(role);
            dataBaseContext.SaveChanges();

            return "Added Successfully!!!";

        }
        public object DeleteRole(int id)
        {
            var role = dataBaseContext.Roles.Find(id);
            if (role == null)
            {
                return "NotFound !!!";
            }

            dataBaseContext.Roles.Remove(role);
            dataBaseContext.SaveChanges();

            return "Successfully Deleted!!!";
        }
    }
}
