using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Context.DataAccess
{
   public interface IGenericRepositry<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        List<TEntity> GetAll();

        string Delete(int id);
    }
}
