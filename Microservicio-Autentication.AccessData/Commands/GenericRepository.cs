using Microservicio_Autentication.AccessData.Context;
using Microservicio_Autentication.Domain.Command.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Microservicio_Autentication.AccessData.Commands
{
    public class GenericRepository<T>: IRepository<T> where T : class
    {

        protected GenericContex Context;
        public GenericRepository(GenericContex contexto)
        {
            this.Context = contexto;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteBy(int id)
        {
            T entity = FindBy(id);
            Delete(entity);
        }

        public T FindBy(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> Traer()
        {
            List<T> query = Context.Set<T>().ToList();
            return query;
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string[] includeProperties = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (includeProperties != null)
                foreach (string includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

            return query.Where(predicate);
        }

    }
}
