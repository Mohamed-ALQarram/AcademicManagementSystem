using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AttendanceService
    {
        private readonly IAttendanceRepository attendanceRepo;

        public AttendanceService(IAttendanceRepository attendanceRepo)
        {
            this.attendanceRepo = attendanceRepo;
        }

        public void CreateAttendance(Attendance attendance)
        {
            if (attendance == null) throw new ArgumentNullException();
            attendanceRepo.Add(attendance);
            attendanceRepo.SaveChanges();
        }
        public void EditAttendance(Attendance attendance)
        {
            if (attendance == null) throw new ArgumentNullException();
            attendanceRepo.Update(attendance);
            attendanceRepo.SaveChanges();
        }
        public void DeleteAttendance(int Id)
        {
            attendanceRepo.Delete(Id);
            attendanceRepo.SaveChanges();
        }
        public Attendance GetAttendance(int Id)
        {
            var Attendance =attendanceRepo.GetById(Id);
            if(Attendance == null) throw new NullReferenceException("Invalid Id");
            return Attendance;
        }
        public List<Attendance> GetAllAttendances()
        {
            var Attendances =attendanceRepo.GetAll().ToList();
            if (Attendances == null) return new List<Attendance>();
            else return Attendances;
        }

        public List<Student> GetLateStudents(int SectionId)
        {
            var LateStudents= attendanceRepo.GetLateStudents(SectionId).ToList();
            if (LateStudents ==null) return new List<Student>();
                return LateStudents;
        }
        public List<Student> GetPresentStudent(int SectionId)
        {
            var PresentStudents = attendanceRepo.GetPresentStudent(SectionId).ToList();
            if (PresentStudents == null) return new List<Student>();
            return PresentStudents;
        }
        public List<Student> GetAbsentStudent(int SectionId)
        {
            var AbsentStudent = attendanceRepo.GetAbsentStudent(SectionId).ToList();
            if (AbsentStudent == null) return new List<Student>();
            return AbsentStudent;
        }
        public List<Student> GetExecusedStudent(int SectionId)
        {
            var ExecusedStudent = attendanceRepo.GetExecusedStudent(SectionId).ToList();
            if (ExecusedStudent == null) return new List<Student>();
            return ExecusedStudent;
        }
        public List<Attendance> GetAllStudentAttendaces(int StudentId)
        {
            var Attendances = attendanceRepo.GetAllStudentAttendaces(StudentId).ToList();
            if (Attendances == null) return new List<Attendance>();
            return Attendances;
        }
        public List<Attendance> GetStudentAttendance(int StudentId, int SectionId)
        {
            var Attendances = attendanceRepo.GetStudentAttendance(StudentId, SectionId).ToList();
            if (Attendances == null) return new List<Attendance>();
            return Attendances;
        }

    }
}
