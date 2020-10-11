﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Microservicio_Autentication.Domain.Command.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        List<T> Traer();
        void Update(T entity);
        void Delete(T entity);
        void DeleteBy(int id);
        T FindBy(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string[] includeProperties = null);
    }
}