﻿using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetById(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
