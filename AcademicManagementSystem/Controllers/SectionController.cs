using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SectionService sectionService;

        public SectionController(SectionService sectionService)
        {
            this.sectionService = sectionService;
        }
        [HttpGet]
        public ActionResult<List<Section>> GetAllSections()
        {
            return sectionService.getAllSections();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Section> GetSection(int id)
        {
            return sectionService.GetSection(id);
        }
        [HttpGet("Students/{SectionId:int}")]
        public ActionResult<List<Student>> GetSectionStudents(int SectionId)
        {
            return sectionService.GetSectionStudents(SectionId);
        }
        
        [HttpGet("SchdulesWithRoom/{SectionId:int}")]
        public ActionResult<List<Schedule>> GetSectionSchedulesWithRoom(int SectionId)
        {
            return sectionService.GetSectionSchedulesWithRoom(SectionId);
        }
        
        [HttpGet("Schedule/{SectionId:int}")]
        public ActionResult<List<Schedule>> GetSectionSchedules(int SectionId)
        {
            return sectionService.GetSectionSchedules(SectionId);
        }

        [HttpPost]
        public ActionResult CreateSection(CreateSectionDTO Section)
        {
            sectionService.CreateSection(
            new Section
            {
                InstructorId = Section.InstructorId,
                CourseId = Section.CourseId,
                Capacity = Section.Capacity,
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditSection(UpdateSectionDTO Section)
        {
            sectionService.EditSection(
            new Section
            {
                Id = Section.SectionId,
                InstructorId = Section.InstructorId,
                CourseId = Section.CourseId,
                Capacity = Section.Capacity,
            });
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult DeleteSection(int Id)
        {
            sectionService.DeleteSection(Id);
            return NoContent();
        }


    }
}
