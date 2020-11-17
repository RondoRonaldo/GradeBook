using API_Contracts.Models.StudentModels;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterStudentModel, StudentEntity>();
            CreateMap<StudentEntity, StudentModel>();
            CreateMap<StudentEntity, StudentModel>();
        }
    }
}
