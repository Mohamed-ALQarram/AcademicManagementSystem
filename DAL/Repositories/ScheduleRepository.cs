using Core;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.CompositeEntityKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ScheduleRepository : CompositeKeyRepository<Schedule, ScheduleKey>, IScheduleRepository
    {
        private readonly AppDbContext context;

        public ScheduleRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Schedule> GetSchdulesByRoom(int RoomId)
            => context.Schedules.Where(x => x.RoomId == RoomId).AsNoTracking();            

        public IQueryable<Schedule> GetSchdulesBySection(int SectionId)
            => context.Schedules.Where(x => x.SectionId == SectionId).AsNoTracking();
        public IQueryable<Schedule> GetSchdulesBySectionWithRoom(int SectionId)
            => context.Schedules.Where(x => x.SectionId == SectionId).Include(x=>x.Room).AsNoTracking();
    }
}
