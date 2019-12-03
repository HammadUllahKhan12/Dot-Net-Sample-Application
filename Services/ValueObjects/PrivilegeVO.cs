using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ValueObjects
{

    [Serializable]
    public class PrivilegeVO
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }

    }
}
