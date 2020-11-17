using API_Contracts.Models.StudentModels;
using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Infrastructure;


namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(RegisterStudentModel model)
        {
            await _unitOfWork.StudentRepository.CreateAsync(_mapper.Map<StudentEntity>(model));
            await _unitOfWork.SaveAsync();
            
        }

        public async Task<IEnumerable<StudentModel>> GetPaginatedResultAsync(int pageIndex, int pageSize)
        {
            var listOfStudentEntities = await _unitOfWork.StudentRepository.GetAllAsQueryable().Page(pageIndex, pageSize); 
            var result = _mapper.Map<IEnumerable<StudentModel>>(listOfStudentEntities);
            return result;
        }


        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentModel> FindAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new Exception(); //todo fine check 
            }
            var request = await _unitOfWork.StudentRepository.FindAsync(id);
               var studentModel = _mapper.Map<StudentModel>(request);
            return studentModel;
        }


    }
}
