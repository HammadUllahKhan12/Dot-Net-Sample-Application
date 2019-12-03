using Entities;
using Services.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ILogin
    {
        string DoLogin(LoginVO login );
    }
}
