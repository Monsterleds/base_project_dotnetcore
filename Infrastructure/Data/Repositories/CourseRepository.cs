using curso.api.Business.Repositories;
using curso.api.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace curso.api.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context) {
            _context = context;
        }
        public void Add(Course course) {
            _context.Course.Add(course);
        }

        public IList<Course> FindByUserCode(int userCode) {
            return _context.Course.Where(u => u.UserCode == userCode).ToList();
        }
        public void Commit() {
            _context.SaveChanges();
        }
    }
}