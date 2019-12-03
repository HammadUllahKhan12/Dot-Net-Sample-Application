using Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
   public class rolePrevilegeService : IRolePrevilegeService
    {
        private readonly DataBaseContext databaseContext;
        public rolePrevilegeService (DataBaseContext context)
        {
            databaseContext = context;
        }

       public object assignPrevilege(int previlegeId, int roleId)
        {
            try
            {
                var roleStattus = databaseContext.Roles.Find(roleId);
                if (roleStattus == null)
                {
                    return "Invalid Role Id !!!";
                }
                else
                {
                    var prevlageStatus = databaseContext.Prevlages.Find(previlegeId);
                    if (prevlageStatus == null)
                    {
                        return "Invalid Prevlage ID!!!";
                    }
                    else
                    {
                        RolePrivilege rolePrevilege = new RolePrivilege();
                        rolePrevilege.PrevillageId = previlegeId;
                        rolePrevilege.RoleId = roleId;

                        databaseContext.RolePrivilege.Add(rolePrevilege);
                        databaseContext.SaveChanges();

                        return "Previlege Assign Successfully to Role !!!";
                    }
                }

            }
            catch
            {
                return "Internal Server Error!!!!";
            }
        }
        public object unAssignPrevilege(int prvilegeId, int roleId)
        {
            try
            {
                var prevlageStatus = databaseContext.Prevlages.Find(prvilegeId);
                if (prevlageStatus == null)
                {
                    return "Invalid Prevlage ID!!!";
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

                        var user = databaseContext.RolePrivilege.Where(p => p.PrevillageId == prvilegeId && p.RoleId == roleId);

                        var status = databaseContext.Remove(databaseContext.RolePrivilege.Single(p => p.PrevillageId == prvilegeId && p.RoleId == roleId));
                        databaseContext.SaveChanges();

                        if (status == null)
                        {
                            return "Error";
                        }
                        else
                        {
                            return "Successfully Unassign the Previlege to the Role";

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
