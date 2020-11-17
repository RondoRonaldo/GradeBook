using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// basic UoW with student repository. lacks other repositories
/// </summary>


namespace DAL.Repositories
{

    public class IdentityUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _applicationContext;

        public IdentityUnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            StudentRepository = new StudentRepository(applicationContext);

        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }

public IRepository<StudentEntity> StudentRepository { get; }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
