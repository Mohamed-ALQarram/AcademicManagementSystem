using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class InstructorRepository : SingleKeyRepository<Instructor>, IInstructorRepository
    {
        private readonly AppDbContext context;

        public InstructorRepository(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public IQueryable GetInstructorLookup()
        {
            return context.Instructors.AsNoTracking().Select(x => new { x.Id, FullName = x.FirstName +" "+ x.LastName });
        }
    }

}


