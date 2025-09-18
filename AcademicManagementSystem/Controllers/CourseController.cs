using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }
        
        [HttpGet]
        public ActionResult<List<Course>> GetAllCourses()
        {
            return courseService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Course> GetCourse(int id)
        {
            return courseService.GetById(id);
        }

        [HttpPost]
        public ActionResult CreateCourse(CreateCourseDTO course)
        {
            courseService.CreateCourse(
            new Course
            {
                Name = course.CourseName,
                Code = course.Code,
                Hours = course.Hours,
                DepartmentId = course.DepartmentId
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditCourse(UpdateCourseDTO course)
        {
            courseService.EditCourse(
            new Course
            {
                Id = course.CourseId,
                Name = course.CourseName,
                Code = course.Code,
                Hours = course.Hours,
                DepartmentId = course.DepartmentId
            });
            return NoContent();
        }
        [HttpDelete("{Id:int}")]
        public ActionResult DeleteCourse(int Id)
        {
            courseService.DeleteCourse(Id);
            return NoContent();
        }

        [HttpGet("Sections/{CourseId:int}")]
        public ActionResult<List<Section>> GetCourseSections(int CourseId)
        {
            return courseService.GetCourseSections(CourseId);
        }

        [HttpGet("EnrolledStudents/{CourseId:int}")]
        public ActionResult<List<Student>> GetCourseEnrolls(int CourseId)
        {
            return courseService.GetEnrolledStudents(CourseId);
        }

    }
}
