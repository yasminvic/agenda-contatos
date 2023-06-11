using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IBaseService<T> where T: class
    {
        Task<T> GetById(int id);
        List<T> GetAll();
        Task<int> Save(T entity);
        Task<int> Delete(int id);
    }
}
