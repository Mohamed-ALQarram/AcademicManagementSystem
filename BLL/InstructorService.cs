using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InstructorService
    {
        private readonly IInstructorRepository instructorRepo;
        private readonly AttendanceService attendanceService;
        private readonly CourseEnrollmentService courseEnrollmentService;

        public InstructorService(IInstructorRepository instructorRepo, AttendanceService attendanceService, CourseEnrollmentService courseEnrollmentService)
        {
            this.instructorRepo = instructorRepo;
            this.attendanceService = attendanceService;
            this.courseEnrollmentService = courseEnrollmentService;
        }
        public void AddInstructor(Instructor instructor) 
        {
            instructorRepo.Add(instructor);
            instructorRepo.SaveChanges();

        }
        public void DeleteInstructor(int instructorId) 
        { 
            instructorRepo.Delete(instructorId);
            instructorRepo.SaveChanges();
        }
        public void UpdateInstructor(Instructor instructor) 
        {
            instructorRepo.Update(instructor);
            instructorRepo.SaveChanges();
        }

        public Instructor GetInstructorById(int instructorId)
        {
            return instructorRepo.GetById(instructorId);
        }
        public IQueryable GetInstructorLookup()
        {
            return instructorRepo.GetInstructorLookup();
        }
        public List<Instructor> GetInstructors() 
        {
        return instructorRepo.GetAll().ToList();
        }

        public void MarkAttendance(Attendance attendance)
        {
            attendanceService.CreateAttendance(attendance);
        }
        public void AddGrade(int studentId, int courseId, double grade)
        {
            var Enrollment= courseEnrollmentService.GetCourseEnrollment(studentId, courseId);
            if (Enrollment == null) throw new NullReferenceException("Invalid Enrollment data");
            Enrollment.Grade = grade;
            courseEnrollmentService.EditEnrollment(Enrollment);
        }
    }
}
