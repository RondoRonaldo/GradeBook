using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public static class Pagination 
    {
        public static async Task<IEnumerable<TSourse>> Page<TSourse>(this IQueryable<TSourse> result, int pageIndex, int pageSize)
            {
            return result is null ? new List<TSourse>() : await result.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }
            }
}
