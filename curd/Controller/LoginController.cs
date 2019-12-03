using Context;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curd.Controller
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        private static DataBaseContext context;
        public LoginController(DataBaseContext _context)
        {
            context = _context;
            loginService = new LoginService(_context);
        }
        [HttpPost]
        public ActionResult DoLogin(LoginVO login)
        {

            var result = loginService.DoLogin(login);
            return Ok(result);
        }
       /* [HttpPost]
        public IActionResult ExternalLogin(string provider,string returnUrl )
        {
            var redirectUrl = Url.Action("ExternalLogiCallback", "Account", new { returnUrl = returnUrl });
            var properties = SignInManager.
        }*/

    }
}
