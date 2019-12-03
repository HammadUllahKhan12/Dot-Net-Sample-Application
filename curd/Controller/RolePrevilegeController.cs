using Context;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curd.Controller
{

    [Route("AssignPrivilegeToRole")]
    [ApiController]
    public class RolePrevilegeController : ControllerBase
    {
        private readonly rolePrevilegeService rolePrevilegeService;


        public RolePrevilegeController (DataBaseContext context)
        {
            rolePrevilegeService = new rolePrevilegeService(context);

        }

        [HttpPost]
        public ActionResult AssignPrevilege(int previlegeId, int roleId)
        {


            var result = rolePrevilegeService.assignPrevilege(previlegeId, roleId);

            return Ok(result);
        }
        [HttpDelete]
        public ActionResult unAssignPrevilege(int previlegeId, int roleId)
        {


            var result = rolePrevilegeService.unAssignPrevilege(previlegeId, roleId);


            return Ok(result);
        }


    }

}
