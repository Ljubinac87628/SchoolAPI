using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class CourseRepository : ICourseRepository
    {
      
        private readonly SchoolDbContext _schoolDbContext;

        public CourseRepository(SchoolDbContext schoolDbContext)
        {
            this._schoolDbContext = schoolDbContext;
        }

        public IEnumerable<Course> AllCourses => throw new NotImplementedException();
    }
}
