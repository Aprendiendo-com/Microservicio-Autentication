using Microservicio_Autentication.AccessData.Context;
using Microservicio_Autentication.Domain.Command.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microservicio_Autentication.AccessData.Commands
{
    public class GenericRepository: IRepository
    {

        protected GenericContex Context;
        public GenericRepository(GenericContex contexto)
        {
            this.Context = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteBy<T>(int id) where T : class
        {
            T entity = FindBy<T>(id);
            Delete<T>(entity);
        }

        public T FindBy<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> Traer<T>() where T : class
        {
            List<T> query = Context.Set<T>().ToList();
            return query;
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

    }
}
