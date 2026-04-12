using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SchoolAPI.Data;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<StudentModel>> Get(int? departmentId)
        {
            try
            {
                var students = _studentRepository.AllStudents;
                if (departmentId.HasValue)
                {
                    students = students.Where(s => s.DepartmentId == departmentId.Value);
                }
                List<StudentModel> result = _mapper.Map<List<StudentModel>>(students);
                return result;
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }
        [HttpGet("id : int")]
        [MapToApiVersion("1.0")]
        public ActionResult<StudentModel> Get(int id)
        {
            try
            {
                var studentEntity = _studentRepository.GetStudentById(id);
                if (studentEntity == null)
                {
                    return NotFound();
                }
                StudentModel student = _mapper.Map<StudentModel>(studentEntity);
                return student;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");

            }

        }
        [HttpGet("id : int")]
        [MapToApiVersion("1.1")]
        public ActionResult<StudentModel> Get11(int id)
        {
            try
            {
                var studentEntity = _studentRepository.GetStudentById(id);
                if (studentEntity == null)
                {
                    return NotFound();
                }
                StudentModel student = _mapper.Map<StudentModel>(studentEntity);
                return student;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");

            }

        }
        [HttpPost]

        public ActionResult<StudentModel> Post(StudentModel student)
        {
            try
            {
                Student studentDM = _mapper.Map<Student>(student);
                Student newStudent = _studentRepository.AddStudent(studentDM);
                StudentModel result = _mapper.Map<StudentModel>(newStudent);

                var location = _linkGenerator.GetPathByAction("Get", "Students", new { id = result.Id });
                return Created(location, result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<StudentModel> Put(int id, StudentModel student)
        {
            try
            {
                var studentDM = _mapper.Map<Student>(student);
                var result = _studentRepository.UpdateStudent(studentDM);
                return Ok(_mapper.Map<StudentModel>(result));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");

            }
        }


    }
}
