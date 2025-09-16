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
        private readonly ICourseRepository courseRepo;
        private readonly DepartmentService departmentService;
        private readonly CourseEnrollmentService courseEnrollmentService;

        public CourseService(ICourseRepository CourseRepo, DepartmentService departmentService, CourseEnrollmentService courseEnrollmentService)
        {
            courseRepo = CourseRepo;
            this.departmentService = departmentService;
            this.courseEnrollmentService = courseEnrollmentService;
        }
        public void CreateCourse(Course course)
        {
            var Dept = departmentService.GetById(course.DepartmentId);
            if (Dept == null) throw new NullReferenceException($"There are no departments with this Id: {course.DepartmentId}");
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
        public List<Course> GetCoursesWithinDepartment(int DeptId)
        {
            var Dept = departmentService.GetDepartmentWithCourses(DeptId);
            if (Dept == null) throw new NullReferenceException($"There are no departments with this Id: {DeptId}");
            var Courses = Dept.Courses?.ToList();
            if (Courses != null) return Courses;
            else return new List<Course>();
        }
        public void DeleteCourse(int CourseId)
        {
            courseRepo.Delete(CourseId);
            courseRepo.SaveChanges();
        }
        public Course getCourseWithSections(int CourseId)
        {
            var course = courseRepo.GetWithSections(CourseId);
            if (course == null) throw new NullReferenceException($"There are no Courses with this Id: {CourseId}");
            return course;
        }

        public List<Student> GetEnrolledStudents(int CourseId)
           => courseEnrollmentService.GetEnrolledStudents(CourseId);
        
    }
}
