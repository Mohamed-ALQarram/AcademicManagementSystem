using Models;
using System.Collections.Generic;

namespace Core
{
    public interface IDepartmentRepository:ISingleKeyRepository<Department>
    {
        public IQueryable<Course> GetCourses(int id);
        public IQueryable<Instructor> GetInstuctors(int id);
        public IQueryable<Intake> GetIntakes(int id);


    }

}
