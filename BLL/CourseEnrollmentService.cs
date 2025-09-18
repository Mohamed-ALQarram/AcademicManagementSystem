
using Core;
using Models;
using Models.CompositeEntityKeys;

namespace BLL
{
    public class CourseEnrollmentService
    {
        private readonly IEnrollmentRepository courseEnrollRepo;

        public CourseEnrollmentService(IEnrollmentRepository courseEnrollRepo)
        {
            this.courseEnrollRepo = courseEnrollRepo;
        }
        public  void AssigenCourses(int Studentid, List<Course>? Courses)
        {
            if(Courses!=null)
            {
                var Enroll = new CourseEnrollment();
                foreach(var Course in Courses)
                {
                    Enroll.StudentId=Studentid;
                    Enroll.CourseId=Course.Id;
                    courseEnrollRepo.Add(Enroll);
                }
                courseEnrollRepo.SaveChanges();
            }
        }
        public  void AssigenCourse(int Studentid, int CourseId)
        {
            courseEnrollRepo.Add(new CourseEnrollment { StudentId = Studentid, CourseId = CourseId });
            courseEnrollRepo.SaveChanges();
        }
        public  void AssigenCourseWithSection(int Studentid, int CourseId, int sectionId)
        {
            courseEnrollRepo.Add(new CourseEnrollment { StudentId = Studentid, CourseId = CourseId, SectionId= sectionId });
            courseEnrollRepo.SaveChanges();
        }
        public void EditEnrollment(CourseEnrollment enrollment)
        {
            courseEnrollRepo.Update(enrollment);
            courseEnrollRepo.SaveChanges();
        }
        public CourseEnrollment GetCourseEnrollment(int Studentid, int CourseId)
        {
            var Enroll = courseEnrollRepo.GetById(new CourseEnrollmentKey(Studentid, CourseId));
            if (Enroll == null) throw new NullReferenceException($"This Enrollment not found.");
            return Enroll;
        }
        public List<Course> GetEnrolledCourses(int studentId)
        {
            var Courses = courseEnrollRepo.GetByStudentId(studentId).ToList() ;
            if( Courses == null )return new List<Course>();
            return Courses;
        }
        public List<Student> GetEnrolledStudents(int CourseId)
        {
            var students = courseEnrollRepo.GetByCourseId(CourseId).ToList() ;
            if(students == null )return new List<Student>();
            return students;
        }
        public void DeleteEnrollment(CourseEnrollmentKey Key)
        {
            courseEnrollRepo.Delete(Key);
            courseEnrollRepo.SaveChanges();
        }
    }
}