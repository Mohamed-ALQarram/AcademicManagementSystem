using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAttendanceRepository : ISingleKeyRepository<Attendance>
    {
        public IQueryable<Student> GetLateStudents(int SectionId);
        public IQueryable<Student> GetPresentStudent(int SectionId);
        public IQueryable<Student> GetAbsentStudent(int SectionId);
        public IQueryable<Student> GetExecusedStudent(int SectionId);
        public IQueryable<Attendance> GetAllStudentAttendaces(int StudentId);
        public IQueryable<Attendance> GetStudentAttendance(int StudentId, int SectionId);
    }
}
