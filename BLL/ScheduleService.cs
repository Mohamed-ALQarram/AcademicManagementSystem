using Core;
using Models;
using Models.CompositeEntityKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ScheduleService
    {
        private readonly IScheduleRepository scheduleRepo;

        public ScheduleService(IScheduleRepository scheduleRepo)
        {
            this.scheduleRepo = scheduleRepo;
        }
        public void AddSchedule(Schedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException();
            scheduleRepo.Add(schedule);
            scheduleRepo.SaveChanges();
        }
        public void EditSchedule(Schedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException();
            scheduleRepo.Update(schedule);
            scheduleRepo.SaveChanges();

        }
        public void DeleteSchedule(ScheduleKey Key)
        {
            scheduleRepo.Delete(Key);
        }
        public List<Schedule> GetAllSchedules()
        {
            var Schedules= scheduleRepo.GetAll().ToList();
            if (Schedules is null) return new List<Schedule>();
            return Schedules;
        }
        public Schedule GetSchedule(ScheduleKey Key)
        {
            var Schedule= scheduleRepo.GetById(Key);
            if (Schedule is null) throw new NullReferenceException($"There are no schedules with this Id: ({Key.SectionId}:{Key.RoomId})");
            return Schedule;
        }
        public List<Schedule> GetSchdulesBySection(int SectionId)
        {
            var Schedules = scheduleRepo.GetSchdulesBySection(SectionId).ToList();
            if (Schedules is null) return new List<Schedule>();
            return Schedules;
        }
        public List<Schedule> GetSchdulesByRoom(int RoomId)
        {
            var Schedules = scheduleRepo.GetSchdulesByRoom(RoomId).ToList();
            if (Schedules is null) return new List<Schedule>();
            return Schedules;
        }
        public List<Schedule> GetSchdulesBySectionWithRoom(int SectionId)
        {
            var Schedules = scheduleRepo.GetSchdulesBySectionWithRoom(SectionId).ToList();
            if (Schedules is null) return new List<Schedule>();
            return Schedules;
        }
    }
}
