using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class SectionRepository : IRepository<Section>, ISingleKeyRepository<Section>
    {
        private readonly AppDbContext context;

        public SectionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Section entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Sections.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Section> GetAll()
        {
            return context.Sections.AsNoTracking();
        }

        public Section GetById(int id)
        {
            var Section = context.Sections.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Section == null) throw new NullReferenceException("There is no Section With this Id");
            return Section;
        }

        public void Update(Section entity)
        {
            var Section = context.Sections.Find(entity.Id);
            if (Section != null)
            {
                Section.Capacity = entity.Capacity;
                Section.CourseId = entity.CourseId;
                Section.InstructorId = entity.InstructorId;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Section With this Id");
        }
    }


}


