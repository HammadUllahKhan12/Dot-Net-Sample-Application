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
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace curd.Controller
{
    

    [Route("User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly  UserService _userService;
        public UsersController(DataBaseContext _context)
        {
            _userService = new UserService(_context);
        }


        [Authorize]
        [HttpGet]
        public ActionResult GetUsers()
        {
            List<User> user = new List<User>();
            user = _userService.GetUsers();
            List<Services.ValueObjects.UserVO> rList = new List<Services.ValueObjects.UserVO>();
            user.ForEach(p =>
            {
                Services.ValueObjects.UserVO vo = new Services.ValueObjects.UserVO();
                vo.Name = p.Name;
                vo.Gender = p.Gender;
                vo.Email = p.Email;
                rList.Add(vo);
            });
            return Ok(rList);
            throw new Exception("Error in hamamd user controller");
        }




        /*   [HttpGet("{id}")]
           public ActionResult<Entities.User>GetUser(int id)
           {
                  var user = _userService.GetUser(id);

              if (user == null)
              {
                  return NotFound();
              }
                   return user;
           }*/
        [HttpPost]
         public  ActionResult<Services.ValueObjects.UserVO> PostUser(Services.ValueObjects.UserVO user)
         {
            User newUser = new User();
            newUser.Email = user.Email;
            newUser.Gender = user.Gender;
            newUser.Name = user.Name;
            newUser.Password = user.Password;

            var users =  _userService.PostUser(newUser);

            return Ok(users);
         }

      
        [HttpDelete("{id}")]
        public  ActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);

            return Ok(result);
        }

      /*  [HttpPut("{id}")]
        public ActionResult<Entities.User> PutUser(int id, Entities.User user)
        {
            var result = _userService.PutUser(id, user);
               return Ok(result);
        }
 */
    }
}
