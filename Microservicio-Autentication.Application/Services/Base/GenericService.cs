using Microservicio_Autentication.Domain.Command.BaseRepository;
using Microservicio_Autentication.Domain.Command.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Microservicio_Autentication.Application.Services.Base
{
    public class GenericService<T> : IService<T> where T : class
    {
        protected IRepository<T> Repository;
        

        public GenericService(IRepository<T> repository)
        {
            this.Repository = repository;
        }

        public void Add(T entity)
        {
            Repository.Add(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        public void DeleteBy(int id)
        {
            Repository.DeleteBy(id);
        }

        public T FindBy(int id)
        {
            return Repository.FindBy(id);
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate, string[] includeProperties = null)
        {
            return Repository.FindBy(predicate, includeProperties);
        }

        public List<T> Traer()
        {
            return Repository.Traer();
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }

    }
}
