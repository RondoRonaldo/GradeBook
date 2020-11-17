using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// for now only CRUD operations 
/// </summary>


namespace DAL.Repositories
{
    public class StudentRepository : IRepository<StudentEntity>
    {
        private readonly DbSet<StudentEntity> _dbSet;

        public StudentRepository(ApplicationContext context)
        {
            _dbSet= context.Set<StudentEntity>();
        }

        public async Task<StudentEntity> CreateAsync(StudentEntity item)
        {
           return (await _dbSet.AddAsync(item)).Entity;
        }
        
        public void Delete(StudentEntity item)
        {
            _dbSet.Remove(item);
        }

        public async Task<StudentEntity> FindAsync(string Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public IQueryable<StudentEntity> GetAllAsQueryable()
        {
            return _dbSet;
        }

        public void Update(StudentEntity item)
        {
            _dbSet.Update(item);
        }
    }
}
