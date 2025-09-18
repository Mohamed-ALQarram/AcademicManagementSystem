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
        private readonly ISectionRepository sectionRepo;
        private readonly InstructorService instructorService;
        private readonly ScheduleService scheduleService;

        public SectionService(ISectionRepository sectionRepo, InstructorService instructorService, ScheduleService scheduleService)
        {
            this.sectionRepo = sectionRepo;
            this.instructorService = instructorService;
            this.scheduleService = scheduleService;
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
    
        public List<Section> getAllSections()
        {
            var sections = sectionRepo.GetAll().ToList();
            if(sections == null) return new List<Section> ();
            return sections;
        }
        public List<Student> GetSectionStudents(int SectionId)
        {
            var Students = sectionRepo.GetSectionStudents(SectionId).ToList();
            if(Students is null) return new List<Student> ();
            return Students;
        }
        public List<Section> GetSectionsByCourse(int CourseId)
        {
            var sections = sectionRepo.GetSectionsByCourse(CourseId).ToList();
            if(sections is null) return new List<Section> ();
            return sections;
        }
        public List<Section> GetSectionsByStudent(int StudentId)
        {
            var Students = sectionRepo.GetSectionsByStudent(StudentId).ToList();
            if(Students is null) return new List<Section> ();
            return Students;
        }
        public List<Schedule> GetSectionSchedules(int SectionId)
        {
            return scheduleService.GetSchdulesBySection(SectionId);
        }
        public List<Schedule> GetSectionSchedulesWithRoom(int SectionId)
        {
            return scheduleService.GetSchdulesBySectionWithRoom(SectionId);
        }
        public List<Section> GetSectionsByInstructor(int InstructorId)
        {
            var sections = sectionRepo.GetSectionsByInstructor(InstructorId).ToList();
            if (sections is null) return new List<Section>();
            return sections;
        }
    }
}
