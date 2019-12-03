using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Context.DataAccess
{
    public class GenericRepositry<TEntity> : IGenericRepositry<TEntity> where TEntity : class

    {
        private readonly DataBaseContext dataBaseContext;

        public GenericRepositry(DataBaseContext Context)
        {
            dataBaseContext = Context;
        }
        public void Add(TEntity entity)
        {
           dataBaseContext.Set<TEntity>().Add(entity);
        }
        public List<TEntity> GetAll()
        {
           return dataBaseContext.Set<TEntity>().AsQueryable().ToList<TEntity>();
        }
        public string Delete (int id)
        {
            var temp = dataBaseContext.Set<TEntity>().Find(id);
            if (temp == null)
            {
                return "NO";
            }
            else
            {
                dataBaseContext.Set<TEntity>().Remove(temp);
                return "Successfully Deleted";
            }   
        }
    }
}
