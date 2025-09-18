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
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpGet]
        public ActionResult<List<Attendance>> GetAllAttendances()
        {
            return attendanceService.GetAllAttendances();
        }

        [HttpGet("{SectionId:int}/{StudentId:int}")]
        public ActionResult <List<Attendance>> GetAttendance(int SectionId, int StudentId)
        {
            return attendanceService.GetStudentAttendance(StudentId, SectionId);
        }
       
        [HttpGet("AbsentStudents/{SectionId:int}")]
        public ActionResult <List<Student>> GetAbsentStudents(int SectionId)
        {
            return attendanceService.GetAbsentStudents(SectionId);
        }
        
        [HttpGet("ExecusedStudents/{SectionId:int}")]
        public ActionResult <List<Student>> GetExecusedStudents(int SectionId)
        {
            return attendanceService.GetExecusedStudents(SectionId);
        }
        
        [HttpGet("LateStudents/{SectionId:int}")]
        public ActionResult <List<Student>> GetLateStudents(int SectionId)
        {
            return attendanceService.GetLateStudents(SectionId);
        }
       
        [HttpGet("PresentStudents/{SectionId:int}")]
        public ActionResult <List<Student>> GetPresentStudents(int SectionId)
        {
            return attendanceService.GetPresentStudents(SectionId);
        }
        
        [HttpGet("AllStudentAttendaces/{StudentId:int}")]
        public ActionResult <List<Attendance>> GetAllStudentAttendaces(int StudentId)
        {
            return attendanceService.GetAllStudentAttendaces(StudentId);
        }

        [HttpGet("{Id}")]
        public ActionResult <Attendance> GetAttendance(int Id)
        {
            return attendanceService.GetAttendance(Id);
        }

        [HttpPut]
        public ActionResult EditAttendance(UpdateAttendanceDTO Attendance)
        {
            attendanceService.EditAttendance(
            new Attendance
            {
                StudentId = Attendance.StudentId,
                SectionId = Attendance.SectionId,
                AttendStatus = Attendance.Status,
                Reason = Attendance.Reason
            });
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult DeleteAttendance(int Id)
        {
            attendanceService.DeleteAttendance(Id);
            return NoContent();
        }

    }
}
