using Models;
using Models.CompositeEntityKeys;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EnrollmentRepository : CompositeKeyRepository<CourseEnrollment, CourseEnrollmentKey>, IEnrollmentRepository
    {
        private readonly AppDbContext context;

        public EnrollmentRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetByCourseId(int CourseId)
        {
            return context.CourseEnrollments.Where(x => x.CourseId== CourseId).Select(x => x.Student);
        }

        public IQueryable<Course> GetByStudentId(int StudentId)
        {
            return context.CourseEnrollments.Where(x => x.StudentId == StudentId).Select(x => x.Course);
        }
    }
}
