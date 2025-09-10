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
        [HttpPost]
        public IActionResult AddDepartment(Department department) 
        {
            departmentService.AddDepartment(department);
            return CreatedAtAction("GetById", new { Id = department .Id}, department);
        }

        [HttpPut]
        public IActionResult EditDepartment(Department department) 
        {
            departmentService.UpdateDepartment(department);
            return CreatedAtAction("GetById", department.Id);
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int departmentId)
        {
            departmentService.DeleteDepartment(departmentId);
            return Ok("Department deleted successfully");
        }


    }
}
