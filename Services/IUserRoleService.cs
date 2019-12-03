using Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserRoleService
    {

        object assignRoles(int userId , int roleId);
        object unAssignRole(int userId, int roleId);
    }
}
