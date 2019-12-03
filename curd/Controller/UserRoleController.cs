using Context;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace curd.Controller
{
    [Route("AssignRoleToUser")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        UserRoleService userRoleService;
        public UserRoleController ( DataBaseContext context)
        {
            userRoleService = new UserRoleService(context);
        }
        [HttpPost]
        public ActionResult AssignRole(int userId , int roleId  )
        {
            var result = userRoleService.assignRoles(userId, roleId);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult unAssignRole(int userId, int roleId)
        {
            var result = userRoleService.unAssignRole(userId, roleId);
            return Ok(result);
        }
    }
}
