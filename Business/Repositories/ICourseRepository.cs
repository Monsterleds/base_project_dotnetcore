using curso.api.Business.Entities;
using System.Collections.Generic;

namespace curso.api.Business.Repositories
{
    public interface ICourseRepository
    {
        void Add(Course course);
        IList<Course> FindByUserCode(int userCode);
        void Commit();
    }
}