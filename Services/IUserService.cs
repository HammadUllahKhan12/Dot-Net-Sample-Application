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

        string PostUser(User user);
        string PutUser(int id, User user);

        string DeleteUser(int id);
        bool UserExists(int id);

    }
}

