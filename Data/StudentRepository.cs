using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
           _schoolDbContext = schoolDbContext;
        }
        public IEnumerable<Student> AllStudents
        {
            get { return _schoolDbContext.Students.Include(s => s.Department); }
        }

        public Student AddStudent(Student student)
        {
            _schoolDbContext.Students.Add(student);
            _schoolDbContext.SaveChanges();
            return student;
        }

        public void DeleteStudent(int studentId)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                _schoolDbContext.Students.Remove(student);
                _schoolDbContext.SaveChanges();
            }
        }

        public Student GetStudentById(int studentId)
        {
            return _schoolDbContext.Students.FirstOrDefault(s => s.Id == studentId);
        }

        public Student UpdateStudent(Student student)
        {
            var updatedStudent = _schoolDbContext.Students.FirstOrDefault(s => s.Id == student.Id);
            if (updatedStudent != null)
            {
                updatedStudent.FirstName = student.FirstName;
                updatedStudent.LastName = student.LastName;
                updatedStudent.DepartmentId = student.DepartmentId;
                _schoolDbContext.SaveChanges();
            }
            return updatedStudent;

        }

        StudentRepository IStudentRepository.GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
