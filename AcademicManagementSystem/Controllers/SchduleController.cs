using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CompositeEntityKeys;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchduleController : ControllerBase
    {
        private readonly ScheduleService scheduleService;

        public SchduleController(ScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }
        
        [HttpGet]
        public ActionResult<List<Schedule>> GetAllSchedules()
        {
            return scheduleService.GetAllSchedules();
        }

        [HttpGet("{SectionId:int}/{RoomId:int}")]
        public ActionResult<Schedule> GetSchedule(int SectionId, int RoomId)
        {
            return scheduleService.GetSchedule( new ScheduleKey (SectionId, RoomId));
        }

        [HttpPost]
        public ActionResult CreateSchedule(CreateScheduleDTO Schedule)
        {
            scheduleService.AddSchedule(
            new Schedule
            {
                StartDate = Schedule.StartDate,
                EndDate = Schedule.EndDate,
                DayOfWeek = Schedule.DayOfWeek,
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditSchedule(UpdateScheduleDTO Schedule)
        {
            scheduleService.EditSchedule(
            new Schedule
            {
                SectionId = Schedule.SectionId,
                RoomId = Schedule.RoomId,
                StartDate = Schedule.StartDate,
                EndDate = Schedule.EndDate,
                DayOfWeek = Schedule.DayOfWeek,
            });
            return NoContent();
        }

        [HttpDelete("{SectionId:int}/{RoomId:int}")]
        public ActionResult DeleteSchedule(int SectionId, int RoomId)
        {
            scheduleService.DeleteSchedule(new ScheduleKey(SectionId, RoomId));
            return NoContent();
        }


    }
}
