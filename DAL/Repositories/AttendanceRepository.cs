using Core;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AttendanceRepository : SingleKeyRepository<Attendance>, IAttendanceRepository
    {
        private readonly AppDbContext context;

        public AttendanceRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetAbsentStudent(int SectionId)
            => context.Attendances
            .Where(x=>x.AttendStatus == Models.Enums.AttendStatus.Absent)
            .Select(x=>x.Student);

        public IQueryable<Attendance> GetAllStudentAttendaces(int StudentId)
        => context.Attendances
            .Where(x => x.StudentId == StudentId)
            .AsNoTracking();

        public IQueryable<Student> GetExecusedStudent(int SectionId)
            => context.Attendances
            .Where(x => x.AttendStatus == Models.Enums.AttendStatus.Execused)
            .AsNoTracking()
            .Select(x => x.Student);
        public IQueryable<Student> GetLateStudents(int SectionId)
            => context.Attendances
            .Where(x => x.AttendStatus == Models.Enums.AttendStatus.Late)
            .AsNoTracking()
            .Select(x => x.Student);
        public IQueryable<Student> GetPresentStudent(int SectionId)
            => context.Attendances
            .Where(x => x.AttendStatus == Models.Enums.AttendStatus.Present)
            .AsNoTracking()
            .Select(x => x.Student);

        public IQueryable<Attendance> GetStudentAttendance(int StudentId, int SectionId)
        => context.Attendances
            .Where(x => x.StudentId == StudentId && x.SectionId == SectionId)
            .AsNoTracking();
    }
}
