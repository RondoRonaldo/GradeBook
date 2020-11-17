using API_Contracts.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(RegisterStudentModel model);

        // TODO : this shit
        Task UpdateAsync();
        Task RemoveAsync();

        Task<StudentModel> FindAsync(string id);

        Task<IEnumerable<StudentModel>> GetPaginatedResultAsync(int pageIndex, int pageSize);

    }
}
