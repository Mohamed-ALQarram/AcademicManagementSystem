using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService;
        private readonly CourseEnrollmentService courseEnrollmentService;

        public StudentController(StudentService studentService, CourseEnrollmentService courseEnrollmentService)
        {
            this.studentService = studentService;
            this.courseEnrollmentService = courseEnrollmentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return studentService.GetAllStudents();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudent(int id)
        {
            return studentService.getStudentById(id);
        }
        [HttpGet("Courses/{StudentId:int}")]
        public ActionResult<List<Course>> GetEnrolledCourses(int StudentId)
        {
            return studentService.GetEnrolledCourses(StudentId);
        }
        [HttpGet("Sections/{StudentId:int}")]
        public ActionResult<List<Section>> GetStudentSectons(int StudentId)
        {
            return studentService.GetStudentSectons(StudentId);
        }

        [HttpPost]
        public ActionResult CreateStudent(CreateStudentDTO Student)
        {
            studentService.AddStudent(
            new Student
            {
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                PhoneNumber = Student.PhoneNumber,
                Email = Student.Email,
                IntakeId = Student.IntakeId
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditStudent(CreateStudentDTO Student)
        {
            studentService.UpdateStudent(
            new Student
            {
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                PhoneNumber = Student.PhoneNumber,
                Email = Student.Email,
                IntakeId = Student.IntakeId
            });
            return NoContent();
        }
        
        [HttpDelete("{Id:int}")]
        public ActionResult DeleteStudent(int Id)
        {
            studentService.DeleteStudent(Id);
            return NoContent();
        }

    }
}
