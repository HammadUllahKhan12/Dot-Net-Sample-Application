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

namespace curd.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly  UserService _userService;
        private static DataBaseContext context;
        public UsersController(DataBaseContext _context)
        {
            context = _context;
            _userService = new UserService(_context);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Entities.User>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

           [HttpGet("{id}")]
           public ActionResult<Entities.User>GetUser(int id)
            {
                var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
                 return user;
            }
           [HttpPost]
            public  ActionResult<Entities.User> PostUser(Entities.User user)
            {

            var users =  _userService.PostUser(user);

            return Ok(users);
        }

        private bool UserExists(int id)
           {

            return _userService.UserExists(id);

            }

           [HttpDelete("{id}")]
            public  ActionResult<Entities.User> DeleteUser(int id)
            {
            var result = _userService.DeleteUser(id);

            return Ok(result);
            }

            [HttpPut("{id}")]
            public ActionResult<Entities.User> PutUser(int id, Entities.User user)
            {
            var result = _userService.PutUser(id, user);
               return Ok(result);
           }
 
    }
}
