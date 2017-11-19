using CachedRepositoryPatternSample.Domain;
using CachedRepositoryPatternSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CachedRepositoryPatternSample.Presentation.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet]
        [Route("api/student/getall")]
        public List<Student> GetAllStudents()
        {
            return _studentService.GetStudents().ToList();
        }

        [HttpGet]
        [Route("api/student/getbyid")]
        public Student GetStudentById(Guid? studentId)
        {
            return _studentService.GetStudentById(studentId);
        }
    }
}
