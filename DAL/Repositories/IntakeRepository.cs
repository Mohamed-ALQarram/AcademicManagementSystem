using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class IntakeRepository : IRepository<Intake>, ISingleKeyRepository<Intake>
    {
        private readonly AppDbContext context;

        public IntakeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Intake entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Intakes.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Intake> GetAll()
        {
            return context.Intakes.AsNoTracking();
        }

        public Intake GetById(int id)
        {
            var Intake = context.Intakes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Intake == null) throw new NullReferenceException("There is no Intake With this Id");
            return Intake;
        }

        public void Update(Intake entity)
        {
            var Intake = context.Intakes.Find(entity.Id);
            if (Intake != null)
            {
                Intake.Name = entity.Name;
                Intake.DepartmentId = entity.DepartmentId;
                Intake.StartDate = entity.StartDate;
                Intake.EndDate = entity.EndDate;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Intake With this Id");
        }
    }


}


