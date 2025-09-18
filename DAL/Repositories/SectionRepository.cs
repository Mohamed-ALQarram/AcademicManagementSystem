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
    internal class SectionRepository : SingleKeyRepository<Section>, ISectionRepository
    {
        private readonly AppDbContext context;

        public SectionRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Section> GetSectionsByCourse(int CourseId)
            => context.Sections
                .Where(x => x.CourseId == CourseId)
                .Include(x => x.Schedules)
                .AsNoTracking();
        
        public IQueryable<Section> GetSectionsByInstructor(int InstructorId)
            => context.Sections
                .Where(x => x.InstructorId == InstructorId)
                .Include(x => x.Schedules)
                .AsNoTracking();

        public IQueryable<Section> GetSectionsByStudent(int StudentId)
            => context.Sections
                .Where(x => x.CourseEnrollments.Any(x=>x.StudentId == StudentId))
                .Include(x=>x.Schedules)
                .AsNoTracking();

        public IQueryable<Student> GetSectionStudents(int sectionId)
            => context.Sections
                .Where(s => s.Id == sectionId)
                .SelectMany(s => s.CourseEnrollments)
                .Select(e => e.Student).AsNoTracking();
    }
}
