﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> Save(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        IQueryable<T> GetAll();
        Task<T> GetById(int id);

    }
}
