using System;
using System.Collections.Generic;
using System.Text;

namespace Context.UnitOfWork
{
    public class Unitofwork : IUnitofwork
    {

        private readonly DataBaseContext dataBaseContext;

        public Unitofwork(DataBaseContext _dataBaseContext)
        {
            dataBaseContext = _dataBaseContext;
        }

        public int Complete()
        {
           return dataBaseContext.Save();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
