using Context;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Services.ValueObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class LoginService : ILogin 
    {
        private readonly DataBaseContext databaseContext;
        public LoginService(DataBaseContext dbContext)
        {
            databaseContext = dbContext;
        }
        private string GenerateJSONWebToken(string email)
        {

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Email, email),
              };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("test@text.com",
             "test@text.com",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string DoLogin(LoginVO login)
        {
            var result =  databaseContext.User.Where(p => p.Email == login.Email && p.Password == login.Password);
            if (result == null)
            {
                return "not found";
            }
            else
            {
                var token = GenerateJSONWebToken(login.Email);
                return token;
            }  
        }  
    }
}
