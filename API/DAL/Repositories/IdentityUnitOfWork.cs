using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class IdentityUnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationContext _applicationContext;

        public IdentityUnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            StudentRepository = new StudentRepository(applicationContext);

        }

        

public IRepository<StudentEntity> StudentRepository { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
