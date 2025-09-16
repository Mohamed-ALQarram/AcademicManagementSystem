using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public StudentService(ISingleKeyRepository<Student> studentRepo, IntakeService intakeService, CourseEnrollmentService courseEnrollmentService, DepartmentService departmentService)
        {
            this.studentRepo = studentRepo;
            this.intakeService = intakeService;
            this.courseEnrollmentService = courseEnrollmentService;
            this.departmentService = departmentService;
        }
        public void AddStudent(Student student)
        {
            studentRepo.Add(student);
            studentRepo.SaveChanges();
             int? DeptId= intakeService.GetIntake(student.IntakeId).DepartmentId;
            if(DeptId !=null)
            {
                var Dept = departmentService.GetDepartmentWithCourses((int)DeptId);
                courseEnrollmentService.AssigenCourses(student.Id, Dept.Courses?.ToList());
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
        public List<Student> getStudentWithinIntake(int IntakeId)
        {
            var students  =intakeService.GetIntakeWithStudents(IntakeId).Students?.ToList();
            if (students != null) return students;
            else 
                return new List<Student>();
        }
        public List<Course> GetEnrolledCourses(int studentId)
            => courseEnrollmentService.GetEnrolledCourses(studentId);
    }
}
