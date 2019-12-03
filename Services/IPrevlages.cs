using System;
using System.Collections.Generic;
using System.Text;using Entities;

namespace Services
{
    public interface IPrevlages
    {
        List<Privilege> GetUsersPrevlages();

        Privilege GetUsersPrevlages(int id);

        object PostUserPrevlage( Privilege userprevlages);

    }
}
