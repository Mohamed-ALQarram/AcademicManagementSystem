using Models;

namespace Core
{
    public interface IDepartmentRepository:ISingleKeyRepository<Department>
    {
        public Department? GettWithCourses(int id);
        public Department? GetWithInstuctors(int id);
        public Department? GetWithIntakes(int id);


    }

}
