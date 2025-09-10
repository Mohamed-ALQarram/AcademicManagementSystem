using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Student entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Students.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.AsNoTracking();
        }

        public Student GetById(int id)
        {
            var student = context.Students.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (student == null) throw new NullReferenceException("There is no Student With this Id");
            return student;
        }

        public void Update(Student entity)
        {
            var student = context.Students.Find(entity.Id);
            if (student != null)
            {
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                student.Email = entity.Email;
                student.PhoneNumber = entity.PhoneNumber;
                student.IntakeId = entity.IntakeId;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Student With this Id");
        }
    }

}


