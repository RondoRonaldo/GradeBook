using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
         Task<T> CreateAsync(T item);
         Task<T> FindAsync(string Id);
         void Update(T item);
         void Delete(T item);

        IQueryable<T> GetAllAsQueryable();

    }
}
