using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudentRepository : IRepository<StudentEntity>
    {
        private readonly ApplicationContext _identityDbContext;

        public StudentRepository(ApplicationContext context)
        {
            _identityDbContext= context;
        }

        public async Task<StudentEntity> CreateAsync(StudentEntity item)
        {
           return (await _identityDbContext.Students.AddAsync(item)).Entity;
        }

        public void Delete(StudentEntity item)
        {
            throw new NotImplementedException();
        }

        public Task ReadAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
