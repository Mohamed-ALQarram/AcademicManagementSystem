using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var Departments = departmentService.GetAll();
            if(Departments is not null)
            {
                return Ok(Departments);
            }
            return NotFound("There are no departments yet.");
        }
        
        [HttpGet("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            var Department = departmentService.GetById(Id);
            if(Department is not null)
            {
                return Ok(Department);
            }
            return NotFound("Department Not Found");
        }
        
        [HttpGet("Courses/{departmentId:int}")]
        public ActionResult<List<Course>> GetDepartmentCourses(int departmentId)
        {
            return departmentService.GetDepartmentCourses(departmentId);
        }
        
        [HttpGet("Intakes/{departmentId:int}")]
        public ActionResult<List<Intake>> GetDepartmentIntakes(int departmentId)
        {
            return departmentService.GetDepartmentIntakes(departmentId);
        }
        
        [HttpGet("Instructors/{departmentId:int}")]
        public ActionResult<List<Instructor>> GetDepartmentInstructors(int departmentId)
        {
            return departmentService.GetDepartmentInstructors(departmentId);
        }
        
        [HttpPost]
        public ActionResult AddDepartment(CreateDepartmentDTO department) 
        {

            departmentService.AddDepartment(new Department
            {
                Name = department.Name,
                Description = department.Description
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditDepartment(UpdateDepartmentDTO department) 
        {
            departmentService.EditDepartment(new Department
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            });
            return CreatedAtAction("GetById", department.Id);
        }
        
        [HttpDelete]
        public ActionResult DeleteDepartment(int departmentId)
        {
            departmentService.DeleteDepartment(departmentId);
            return Ok("Department deleted successfully");
        }


    }
}
