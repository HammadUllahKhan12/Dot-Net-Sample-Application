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
    [Route("Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService roleService;
        public RolesController(DataBaseContext _context)
        {
            roleService = new RoleService(_context);
        }
        [HttpGet]
        public ActionResult GetRoles()
        {
            List<Role> roles = roleService.GetRoles();
            List<Services.ValueObjects.RoleVO> rList = new List<Services.ValueObjects.RoleVO>();
            roles.ForEach(p =>
            {
                Services.ValueObjects.RoleVO vo = new Services.ValueObjects.RoleVO();

                vo.Name = p.roleName;
                vo.Code = p.roleCode;
                vo.Description = p.roleDescription;
                rList.Add(vo);
            });
            return Ok(rList);       }
        [HttpGet("{id}")]
        public ActionResult<Services.ValueObjects.RoleVO> GetRole(int id)
        {
            var role = roleService.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                Services.ValueObjects.RoleVO newRole = new Services.ValueObjects.RoleVO();
                newRole.Name = role.roleName;
                newRole.Code = role.roleCode;
                newRole.Description = role.roleDescription;
                return newRole;
            }          
        }
        [HttpPost]
        public ActionResult<Services.ValueObjects.RoleVO> PostRole(Services.ValueObjects.RoleVO roleVo)
        {
            Role newRole = new Role();
            newRole.roleName = roleVo.Name;
            newRole.roleCode = roleVo.Code;
            newRole.roleDescription = roleVo.Description;
            var Role = roleService.PostRole(newRole);

            return Ok(Role);
        }

      /*  [HttpDelete("{id}")]
        public ActionResult<Role>DeleteRole(int id)
        {
            var result = roleService.DeleteRole(id);
            return Ok(result);
        }*/


    }
}
