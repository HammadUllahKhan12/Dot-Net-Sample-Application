using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RolePrivilege
    {
        public int PrevillageId { get; set; }
        public int RoleId { get; set; }
        public Privilege Prevlages { get; set; }
        public Role Role { get; set; }

    }
}
