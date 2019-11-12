using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public  interface IRoleServices
    {
        List<Role> GetRoles();
        Role GetRole(int id);
        object PostRole(Role role);
        object DeleteRole(int id);
       


    }
}
