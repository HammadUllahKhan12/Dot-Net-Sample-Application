using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        List<User> GetUsers();

        User GetUser(int id);

        object PutUser(int id, User user);
        
        object PostUser(User user);
        object DeleteUser(int id);
        bool UserExists(int id);

    }
}

