using System;
using System.Collections.Generic;
using System.Text;

namespace Context.UnitOfWork
{
   public interface IUnitofwork : IDisposable
    {
        int Complete();
    }
}
