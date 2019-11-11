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
    [Route("api/UserPrevlages")]
    [ApiController]

    public class PrevlagesController : ControllerBase
    {
        private readonly UserPrevlagesService _userPrevlageService;

        private static DataBaseContext context;
        public PrevlagesController(DataBaseContext _context)
        {
            context = _context;
            _userPrevlageService = new UserPrevlagesService(_context);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.UserPrevlages>> GetUsersPrevlages()
        {
            var userprevs = _userPrevlageService.GetUsersPrevlages();
            return Ok(userprevs);
        }

     
        [HttpGet("{id}")]
        public ActionResult<Entities.UserPrevlages> GetUsersPrevlages(int id)
        {
            var userprevs = _userPrevlageService.GetUsersPrevlages(id);

            if (userprevs == null)
            {
                return NotFound();
            }
            return Ok(userprevs);
        }
        [HttpPost]
        public ActionResult<Entities.UserPrevlages> PostUser(Entities.UserPrevlages userprev)
        {
            var userPrev = _userPrevlageService.PostUserPrevlage(userprev);
            return Ok(userPrev);
        }

    }
}
