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
        public Department GetDepartmentWithCourses(int departmentId)
        {
            var Dept= departmentRepo.GettWithCourses(departmentId);
            if (Dept is null) throw new NullReferenceException("Invalid Id");
            return Dept;
        }
        public Department GetDepartmentWithInstructors(int departmentId)
        {
            var Dept= departmentRepo.GetWithInstuctors(departmentId);
            if (Dept is null) throw new NullReferenceException("Invalid Id");
            return Dept;

        }
        public Department GetDepartmentWithIntakes(int departmentId)
        {
            var Dept= departmentRepo.GetWithIntakes(departmentId);
            if (Dept is null) throw new NullReferenceException("Invalid Id");
            return Dept;

        }
    }

}
