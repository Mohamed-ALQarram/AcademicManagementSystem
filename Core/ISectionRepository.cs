using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ISectionRepository: ISingleKeyRepository<Section>
    {
        public IQueryable<Student> GetSectionStudents(int SectionId);
        public IQueryable<Section>GetSectionsByCourse(int CourseId);
        public IQueryable<Section> GetSectionsByInstructor(int InstructorId);
        public IQueryable<Section> GetSectionsByStudent(int StudentId);
    }
}
