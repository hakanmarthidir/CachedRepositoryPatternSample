using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CachedRepositoryPatternSample.Domain;
using CachedRepositoryPatternSample.Repositories;

namespace CachedRepositoryPatternSample.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Student GetStudentById(Guid? studentId)
        {
            if (studentId.HasValue && studentId.Value != Guid.Empty)
            {
                return _studentRepository.GetStudentById(studentId.Value);
            }
            return null; 
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
    }
}
