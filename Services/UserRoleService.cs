using Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly DataBaseContext   databaseContext;

        public UserRoleService (DataBaseContext _dataBaseContext)
        {
            databaseContext = _dataBaseContext;
        }

        public object assignRoles(int userId, int roleId)
        {
            try { 
            var userStattus = databaseContext.User.Find(userId);
            if (userStattus == null)
            {
                return "Invalid User Id !!!";
            }
            else
            {
               var roleStatus = databaseContext.Roles.Find(roleId);
                if (roleStatus == null)
                {
                    return "Invalid User Role!!!";
                }
                else
                {
                    UserRole userRole = new UserRole();
                    userRole.UserId = userId;
                    userRole.RoleId = roleId;

                    databaseContext.UserRoles.Add(userRole);
                    databaseContext.SaveChanges();

                    return "Assign Successfully !!!!";
                }
            }

            }
            catch
            {
                return "Internal Server Error!!!!";
            }
        }

        public object unAssignRole(int userId, int roleId)
        {
            try
            {
                var userStattus = databaseContext.User.Find(userId);
                if (userStattus == null)
                {
                    return "Invalid User Id !!!";
                }
                else
                {
                    var roleStatus = databaseContext.Roles.Find(roleId);
                    if (roleStatus == null)
                    {
                        return "Invalid User Role!!!";
                    }
                    else
                    {

                        var user = databaseContext.UserRoles.Where(p => p.UserId == userId && p.RoleId == roleId);

                       var status =  databaseContext.Remove(databaseContext.UserRoles.Single(p => p.UserId == userId && p.RoleId == roleId));
                        databaseContext.SaveChanges();

                        if (status == null)
                        {
                            return "Error";
                        }
                        else
                        {
                            return "Successfully Unassign the role to that User";
                            
                        }

                        
                    }
                }

            }
            catch
            {
                return "Internal Server Error!!!!";
            }
        }

    }


}

