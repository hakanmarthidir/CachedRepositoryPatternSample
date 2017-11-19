using CachedRepositoryPatternSample.Domain;
using CachedRepositoryPatternSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CachedRepositoryPatternSample.CachedRepositories
{
    public class CachedStudentRepository : StudentRepository
    {
        private static readonly object cachedObject = new object();
        private static readonly string cacheKeyGetStudents = "GetStudents";
        private static readonly string cacheKeyStudentById = "StudentById";

        public override IEnumerable<Student> GetStudents()
        {            
            var result = HttpRuntime.Cache[cacheKeyGetStudents] as List<Student>;
            if (result == null)
            {
                lock (cachedObject)
                {
                    result = HttpRuntime.Cache[cacheKeyGetStudents] as List<Student>;
                    if (result == null)
                    {
                        result = base.GetStudents().ToList();
                        HttpRuntime.Cache.Insert(cacheKeyGetStudents, result, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }

        public override Student GetStudentById(Guid? studentId)
        {
            var cacheKey = string.Format("{0}_{1}", cacheKeyStudentById, studentId.Value);
            var result = HttpRuntime.Cache[cacheKey] as Student;
            if (result == null)
            {
                lock (cachedObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as Student;
                    if (result == null)
                    {
                        result = base.GetStudentById(studentId);
                        HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }

    }
}
