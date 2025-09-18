using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService instructorService;

        public InstructorController(InstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        [HttpGet]
        public ActionResult<List<Instructor>> GetAllInstructors()
        {
            return instructorService.GetInstructors();
        }
        [HttpGet("{Id:int}")]
        public ActionResult<Instructor> GetById(int Id)
        {
            return instructorService.GetInstructorById(Id);
        }
        [HttpPost("MarkAttendance")]
        public ActionResult<Instructor> MarkAttendance(CreateAttendanceDTO attendanceFromRequest)
        {
            instructorService.MarkAttendance(new Attendance
            {
                StudentId = attendanceFromRequest.StudentId,
                SectionId = attendanceFromRequest.SectionId,
                AttendStatus = attendanceFromRequest.Status,
                Reason = attendanceFromRequest.Reason
            });
            return Created();
        }

        [HttpPost("AddGrade")]
        public ActionResult<Instructor> AddGrade(AddGradeDTO grade)
        {
            instructorService.AddGrade(grade.StudentId, grade.CourseId, grade.Grade);
            return Created();
        }

        [HttpPost]
        public ActionResult<Instructor> AddInstructor(AddInstructorDTO instructorDTO)
        {
            Instructor instructor = new Instructor
            {
                FirstName = instructorDTO.FirstName,
                LastName = instructorDTO.LastName,
                Salary = instructorDTO.Salary,
                Email = instructorDTO.Email,
                PhoneNumber = instructorDTO.PhoneNumber,
                DepartmentId = instructorDTO.DepartmentId
            };
            instructorService.AddInstructor(instructor);
            return instructor;
        }
        [HttpPut]
        public ActionResult EditInstructor(Instructor instructor)
        {
            instructorService.UpdateInstructor(instructor);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteInstructor(int Id)
        {
            instructorService.DeleteInstructor(Id);
            return NoContent();
        }
    
        
    }
}
