using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IRolePrevilegeService
    {
        object assignPrevilege(int prvilegeId, int roleId);
        object unAssignPrevilege(int prvilegeId, int roleId);
    }
}
