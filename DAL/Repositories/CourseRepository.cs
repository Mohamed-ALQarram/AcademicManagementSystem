using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class CourseRepository : IRepository<Course>, ISingleKeyRepository<Course>
    {
        private readonly AppDbContext context;

        public CourseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Course entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Courses.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Course> GetAll()
        {
            return context.Courses.AsNoTracking();
        }

        public Course GetById(int id)
        {
            var Course = context.Courses.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Course == null) throw new NullReferenceException("There is no Course With this Id");
            return Course;
        }

        public void Update(Course entity)
        {
            var Course = context.Courses.Find(entity.Id);
            if (Course != null)
            {
                Course.Name = entity.Name;
                Course.Code = entity.Code;
                Course.Hours = entity.Hours;
                Course.DepartmentId = entity.DepartmentId;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Course With this Id");
        }
    }

}


