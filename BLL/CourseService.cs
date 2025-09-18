using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseService
    {
        private readonly ISingleKeyRepository<Course> courseRepo;
        private readonly SectionService sectionService;
        private readonly CourseEnrollmentService courseEnrollmentService;

        public CourseService(ISingleKeyRepository<Course> CourseRepo, SectionService sectionService, CourseEnrollmentService courseEnrollmentService)
        {
            courseRepo = CourseRepo;
            this.sectionService = sectionService;
            this.courseEnrollmentService = courseEnrollmentService;
        }
        public void CreateCourse(Course course)
        {
            courseRepo.Add(course);
            courseRepo.SaveChanges();

        }
        public Course GetById(int CourseId)
        {
            var course = courseRepo.GetById(CourseId);
            if (course == null) throw new NullReferenceException($"There are no Courses with this Id: {CourseId}");
            return course;
        }
        public void EditCourse(Course course)
        {
            courseRepo.Update(course);
            courseRepo.SaveChanges();
        }
        public void DeleteCourse(int CourseId)
        {
            courseRepo.Delete(CourseId);
            courseRepo.SaveChanges();
        }
        public List<Section> GetCourseSections(int CourseId)
        {
            var Sections = sectionService.GetSectionsByCourse(CourseId);
            if (Sections == null) throw new NullReferenceException($"There are no Courses with this Id: {CourseId}");
            return Sections;
        }

        public List<Student> GetEnrolledStudents(int CourseId)
           => courseEnrollmentService.GetEnrolledStudents(CourseId);
        
    }
}
