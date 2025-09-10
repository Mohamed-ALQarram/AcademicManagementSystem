using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class InstructorRepository : IRepository<Instructor>
    {
        private readonly AppDbContext context;

        public InstructorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Instructor entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Instructors.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Instructor> GetAll()
        {
            return context.Instructors.AsNoTracking();
        }

        public Instructor GetById(int id)
        {
            var instructor = context.Instructors.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (instructor == null) throw new NullReferenceException("There is no Instructor With this Id");
            return instructor;
        }

        public void Update(Instructor entity)
        {
            var instructor = context.Instructors.Find(entity.Id);
            if (instructor != null)
            {
                instructor.FirstName = entity.FirstName;
                instructor.LastName = entity.LastName;
                instructor.Email = entity.Email;
                instructor.Salary = entity.Salary;
                instructor.PhoneNumber = entity.PhoneNumber;
                instructor.DepartmentId = entity.DepartmentId;
                instructor.HireDate = entity.HireDate;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Instructor With this Id");
        }
    }

}


