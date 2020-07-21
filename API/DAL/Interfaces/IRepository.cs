using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
         Task<T> CreateAsync(T item);
         Task ReadAsync(string Id);
         void Update(T item);
         void Delete(T item);

        

    }
}
