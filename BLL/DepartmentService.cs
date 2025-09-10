using Core;
using Models;

namespace BLL
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public void AddDepartment(Department department)
        {
            departmentRepository.Add(department);
        }
        public void UpdateDepartment(Department department)
        {
            departmentRepository.Update(department);
        }
        public void DeleteDepartment(int departmentId)
        {
            departmentRepository.Delete(departmentId);
        }
        public List<Department> GetAll()
        {
            return departmentRepository.GetAll().ToList();
        }
        public Department GetById(int departmentId)
        {
            return departmentRepository.GetById(departmentId);
        }
    }
}
