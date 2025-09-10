using Core;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.CompositeEntityKeys;

namespace DAL.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>,ICompisiteKeyRepository<Schedule, ScheduleKey>
    {
        private readonly AppDbContext context;

        public ScheduleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Schedule entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(ScheduleKey key)
        {
            context.Schedules.Where(x => x.SectionId == key.SectionId && x.RoomId == key.RoomId)
                .ExecuteDelete();
        }

        public IEnumerable<Schedule> GetAll()
        {
            return context.Schedules.AsNoTracking();
        }

        public Schedule GetById(ScheduleKey key)
        {
            var Schedule = context.Schedules
                .AsNoTracking()
                .FirstOrDefault(x => x.SectionId == key.SectionId && x.RoomId == key.RoomId);
            if (Schedule == null) throw new NullReferenceException("There is no Schedule With this Id");
            return Schedule;
        }

        public void Update(Schedule entity)
        {
            var Schedule = context.Schedules.Find(entity);
            if (Schedule != null)
            {
                Schedule.SectionId = entity.SectionId;
                Schedule.RoomId = entity.RoomId;
                Schedule.DayOfWeek = entity.DayOfWeek;
                Schedule.StartDate = entity.StartDate;
                Schedule.EndDate = entity.EndDate;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Schedule With this Id");
        }
    }


}


