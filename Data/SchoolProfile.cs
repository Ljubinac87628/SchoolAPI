using AutoMapper;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            this.CreateMap<Student, StudentModel>()
            .ForMember(s => s.NameOfDepartment, b => b.MapFrom(c => c.Department.Name));

            this.CreateMap<StudentModel, Student>();

            this.CreateMap<Final, FinalModel>();

            this.CreateMap<FinalModel, Final>();

        }
    }
}
