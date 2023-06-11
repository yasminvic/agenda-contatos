using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MySQLContext _context;

        public BaseRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<int> Save(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
