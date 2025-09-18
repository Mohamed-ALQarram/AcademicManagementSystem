using Core;
using Models;

namespace BLL
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository departmentRepo;

        public DepartmentService(IDepartmentRepository departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        public void AddDepartment(Department department)
        {
            departmentRepo.Add(department);
            departmentRepo.SaveChanges();

        }
        public void EditDepartment(Department department)
        {
            departmentRepo.Update(department);
            departmentRepo.SaveChanges();
        }
        public void DeleteDepartment(int departmentId)
        {
            departmentRepo.Delete(departmentId);
            departmentRepo.SaveChanges();
        }
        public List<Department> GetAll()
        {
            return departmentRepo.GetAll().ToList();
        }
        public Department GetById(int departmentId)
        {
            return departmentRepo.GetById(departmentId);
        }
        public List<Course> GetDepartmentCourses(int departmentId)
        {
            var Courses = departmentRepo.GetCourses(departmentId).ToList();
            if (Courses is null) return new List<Course>();
            return Courses;
        }
        public List<Instructor> GetDepartmentInstructors(int departmentId)
        {
            var instructors= departmentRepo.GetInstuctors(departmentId).ToList();
            if (instructors is null) return new List<Instructor>();
            return instructors;
        }
        public List<Intake> GetDepartmentIntakes(int departmentId)
        {
            var Intakes = departmentRepo.GetIntakes(departmentId).ToList();
            if (Intakes is null) return new List<Intake>();
            return Intakes;
        }
    }

}
