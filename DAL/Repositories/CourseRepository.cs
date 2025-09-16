using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class CourseRepository : SingleKeyRepository<Course>, ICourseRepository
    {
        private readonly AppDbContext context;
        public CourseRepository(AppDbContext context):base(context) 
        {
            this.context = context;
        }
        public Course? GetWithSections(int id)
        {
            return context.Courses.Include(x => x.Sections).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }

}


