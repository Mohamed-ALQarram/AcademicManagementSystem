using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class IntakeRepository : SingleKeyRepository<Intake>, IIntakeRepository
    {
        private readonly AppDbContext context;

        public IntakeRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public Intake? GetIntakeWithDepartment(int IntakeId)
            => context.Intakes.Include(x=>x.Department).AsNoTracking().FirstOrDefault(x=>x.Id==IntakeId);

        public Intake? GetIntakeWithStudents(int IntakeId)
            => context.Intakes.Include(x => x.Students).AsNoTracking().FirstOrDefault(x => x.Id == IntakeId);

    }


}


