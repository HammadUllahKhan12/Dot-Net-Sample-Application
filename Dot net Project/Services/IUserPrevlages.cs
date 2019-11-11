using System;
using System.Collections.Generic;
using System.Text;using Entities;

namespace Services
{
    public interface IUserPrevlages
    {
        List<UserPrevlages> GetUsersPrevlages();

        UserPrevlages GetUsersPrevlages(int id);

        object PostUserPrevlage( UserPrevlages userprevlages);

    }
}
