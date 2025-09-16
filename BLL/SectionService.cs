using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SectionService
    {
        private readonly ISingleKeyRepository<Section> sectionRepo;
        private readonly CourseService courseService;
        private readonly InstructorService instructorService;

        public SectionService(ISingleKeyRepository<Section> sectionRepo, CourseService courseService, InstructorService instructorService)
        {
            this.sectionRepo = sectionRepo;
            this.courseService = courseService;
            this.instructorService = instructorService;
        }
        public void CreateSection(Section section)
        {
            var instructor = instructorService.GetInstructorById(section.InstructorId);
            if (instructor == null) throw new NullReferenceException($"There are no Instructors with Id: {section.InstructorId}");
            var course = instructorService.GetInstructorById(section.CourseId);
            if (course == null) throw new NullReferenceException($"There are no courses with Id: {section.CourseId}");
            sectionRepo.SaveChanges();
        }
        public void DeleteSection(int sectionId) 
        {
            sectionRepo.Delete(sectionId);
            sectionRepo.SaveChanges();
        }
        public Section GetSection(int sectionId) 
        {
            var section = sectionRepo.GetById(sectionId);
            if(section == null) throw new NullReferenceException($"There are no sections with Id: {sectionId}");
            return section;
        }
        public void EditSection(Section section)
        {
            sectionRepo.Update(section);
            sectionRepo.SaveChanges();
        }

        public void AssignInstructor(int sectionId, int instructorId)
        {
            var section =sectionRepo.GetById(sectionId);
            if( section == null) throw new NullReferenceException($"There are no sections with Id: {sectionId}");
            var instructor= instructorService.GetInstructorById(instructorId);
            if (instructor == null) throw new NullReferenceException($"There are no instructors with Id: {instructorId}");
            section.InstructorId = instructorId;
            sectionRepo.Update(section);
        }
        public List<Section> GetSectionsByCourse(int CourseId)
        {
            var Sections = courseService.getCourseWithSections(CourseId).Sections?.ToList();
            if(Sections!= null) return Sections;
            else 
                return new List<Section>();
        }
    }
}
