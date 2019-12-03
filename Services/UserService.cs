using Context;
using Context.DataAccess;
using Context.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text; 

namespace Services
{
   public class UserService : IUserService 
    {

        private readonly DataBaseContext databaseContext;
        private readonly GenericRepositry<User> GenericRepositry;
        private readonly Unitofwork unitofwork;

        public UserService(DataBaseContext dbContext)
        {
            GenericRepositry =  new GenericRepositry<User>(dbContext);
            unitofwork = new Unitofwork(dbContext);
            databaseContext = dbContext;
        }
       
        public List<User> GetUsers()
        {
            return GenericRepositry.GetAll();
            
        }
        public User GetUser(int id)
        {
            return databaseContext.User.Find(id);
        }
        public string PostUser(User user)
        {
            bool result = IsValid(user.Email);
            if (result)
            {
                if (user.Gender == "Male" || user.Gender == "Female")
                {
                    GenericRepositry.Add(user);
                    unitofwork.Complete();
                    return "Added Successfully";
                }
                else
                {
                    return "Invalid Gender is Provided!!!!";
                }
            }
            else
            {
                return "Invalid Email Provided !!!";
            }     
        }
        public bool IsValid(string emailaddress)
        {
           try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool UserExists(int id)
        {
            return databaseContext.User.Any(e => e.UserId == id); 
        }
        public string PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return "Both Keys Are Different!!!";
            }
            databaseContext.Entry(user).State = EntityState.Modified;
            try
            {
               databaseContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return "Invalid Key Enter!!!";
                }
                else
                {
                    throw;
                }
            }
            return "User Updated Successfully!!!";
        }
        public string DeleteUser(int id)
        {
            var result = GenericRepositry.Delete(id);
           if ( result == "NO")
            {
                return "No User Found";
            }
           else
            {
                unitofwork.Complete();
                return result;
            }
        }
        
    }
}