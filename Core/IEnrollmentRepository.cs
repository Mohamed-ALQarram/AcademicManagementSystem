using Models;
using Models.CompositeEntityKeys;

namespace Core
{
    public interface IEnrollmentRepository:ICompositeKeyRepository<CourseEnrollment,CourseEnrollmentKey>
    {
        public IQueryable<Course> GetByStudentId(int StudentId);
        public IQueryable<Student> GetByCourseId(int CourseId);
    }
}
