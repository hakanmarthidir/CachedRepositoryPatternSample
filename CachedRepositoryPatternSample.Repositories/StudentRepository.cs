using CachedRepositoryPatternSample.Domain;
using System;
using System.Collections.Generic;

namespace CachedRepositoryPatternSample.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public virtual Student GetStudentById(Guid? studentId)
        {
            //Code : Get student by Id from database 
            return new Student();
        }

        public virtual IEnumerable<Student> GetStudents()
        {
            //Code : Get students from database 
            return new List<Student>();
        }
    }
}
