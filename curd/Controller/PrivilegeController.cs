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
using System.Collections;

namespace UserApp.Controller
{
    [Route("Privilege")]
    [ApiController]

    public class PrivilegeController : ControllerBase
    {
        private readonly PrivilegeService _userPrevlageService;

        private static DataBaseContext context;
        public PrivilegeController(DataBaseContext _context)
        {
            context = _context;
            _userPrevlageService = new PrivilegeService(_context);

        }

        [HttpGet]
        public ActionResult GetPrevlages()
        {
            List<Privilege> userprevs = _userPrevlageService.GetUsersPrevlages();
            List<Services.ValueObjects.PrivilegeVO> pList = new List<Services.ValueObjects.PrivilegeVO>();
            userprevs.ForEach(p =>
               {
                   Services.ValueObjects.PrivilegeVO vo = new Services.ValueObjects.PrivilegeVO();
                   
                   vo.Name = p.PrevlegeName;
                   vo.Code = p.PrevlegeCode;
                   vo.Description = p.PrevlegeDescription;
                   pList.Add(vo);
               }); 
            return Ok(pList);
        }


      /*  [HttpGet("{id}")]
        public ActionResult<Entities.Privilege> GetUsersPrevlages(int id)
        {
            var userprevs = _userPrevlageService.GetUsersPrevlages(id);

            if (userprevs == null)
            {
                return NotFound();
            }
            return Ok(userprevs);
        }*/
        [HttpPost]
        public ActionResult<Services.ValueObjects.PrivilegeVO> PostPrivilege(Services.ValueObjects.PrivilegeVO privilege)
        {
            Entities.Privilege privilege1 = new Entities.Privilege();
            privilege1.PrevlegeName = privilege.Name;
            privilege1.PrevlegeCode = privilege.Code;
            privilege1.PrevlegeDescription = privilege.Description;
            var result = _userPrevlageService.PostUserPrevlage(privilege1);
           


            return Ok(result);
        }

    }
}
