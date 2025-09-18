using Models;
using Models.CompositeEntityKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IScheduleRepository: ICompositeKeyRepository<Schedule, ScheduleKey>
    {
        public IQueryable<Schedule> GetSchdulesBySection(int SectionId);
        public IQueryable<Schedule> GetSchdulesBySectionWithRoom(int SectionId);
        public IQueryable<Schedule> GetSchdulesByRoom(int RoomId);
    }
}
