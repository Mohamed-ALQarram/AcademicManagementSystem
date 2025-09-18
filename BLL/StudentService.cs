using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentService
    {
        private readonly ISingleKeyRepository<Student> studentRepo;
        private readonly IntakeService intakeService;
        private readonly CourseEnrollmentService courseEnrollmentService;
        private readonly DepartmentService departmentService;
        private readonly SectionService sectionService;

        public StudentService(ISingleKeyRepository<Student> studentRepo, IntakeService intakeService,
            CourseEnrollmentService courseEnrollmentService, DepartmentService departmentService,
            SectionService sectionService
            )
        {
            this.studentRepo = studentRepo;
            this.intakeService = intakeService;
            this.courseEnrollmentService = courseEnrollmentService;
            this.departmentService = departmentService;
            this.sectionService = sectionService;
        }
        public void AddStudent(Student student)
        {
            studentRepo.Add(student);
            studentRepo.SaveChanges();
             int? DeptId= intakeService.GetIntake(student.IntakeId).DepartmentId;
            if(DeptId !=null)
            {
                var Courses = departmentService.GetDepartmentCourses((int)DeptId);
                courseEnrollmentService.AssigenCourses(student.Id, Courses);
            }
        }
        public void UpdateStudent(Student student)
        {
            studentRepo.Update(student);
            studentRepo.SaveChanges();
        }
        public void DeleteStudent(int studentId)
        {
            studentRepo.Delete(studentId);
            studentRepo.SaveChanges();
        }
        public Student getStudentById(int studentId)
        {
            var Student= studentRepo.GetById(studentId);
            if (Student != null)
                return Student;
            else
                throw new NullReferenceException($"There are no students with this Id: {studentId}");
        }
        public List<Course> GetEnrolledCourses(int studentId)
            => courseEnrollmentService.GetEnrolledCourses(studentId);
        public List<Student> GetAllStudents()
        {
            var Students = studentRepo.GetAll().ToList();
            if (Students is null) return new List<Student>();
            return Students;
        }
        public List<Section> GetStudentSectons(int StudentId)
        {
            var Sections = sectionService.GetSectionsByStudent(StudentId);
            if (Sections is null) return new List<Section>();
            return Sections;
        }
    }
}
