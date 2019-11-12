using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Context;
using Entities;
using Services;

namespace curd.Controller
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly RoleService roleService;
        public RolesController(DataBaseContext _context)
        {
            roleService = new RoleService(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetUsers()
        {
            var roles = roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetUser(int id)
        {
            var role = roleService.GetRole(id);

            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        [HttpPost]
        public ActionResult<Role> PostRole(Role role)
        {

            var Role = roleService.PostRole(role);

            return Ok(Role);
        }

      

        [HttpDelete("{id}")]
        public ActionResult<Role>DeleteUser(int id)
        {
            var result = roleService.DeleteRole(id);

            return Ok(result);
        }


    }
}
