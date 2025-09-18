using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IntakeService
    {
        private readonly IIntakeRepository intakeRepo;
        private readonly DepartmentService departmentService;

        public IntakeService(IIntakeRepository intakeRepo, DepartmentService departmentService)
        {
            this.intakeRepo = intakeRepo;
            this.departmentService = departmentService;
        }

        public void CreatIntake(int DeptId, Intake intake)
        {
            if (intake == null) throw new ArgumentNullException();
            var Dept=departmentService.GetById(DeptId);
            if(Dept == null) throw new NullReferenceException("Invalid Department Id");
            intake.DepartmentId = DeptId;
            intakeRepo.Add(intake);
            intakeRepo.SaveChanges();
        }
        public void CreatIntake(Intake intake)
        {
            intakeRepo.Add(intake);
            intakeRepo.SaveChanges();
        }

        public void delete(int IntakeId)
        {
            intakeRepo.Delete(IntakeId);
            intakeRepo.SaveChanges();
        }

    
        public void EditIntake(Intake intake)
        {
            intakeRepo.Update(intake);
            intakeRepo.SaveChanges();
        }
   
        public Intake GetIntake(int Id)
        {
            var intake = intakeRepo.GetById(Id);
            if (intake == null) throw new NullReferenceException($"There are no Intakes with this Id: {Id}");
            return intake;
        }
        public Intake GetIntakeWithDepartment(int Id)
        {
            var intake = intakeRepo.GetIntakeWithDepartment(Id);
            if (intake == null) throw new NullReferenceException($"There are no Intakes with this Id: {Id}");
            return intake;
        }
        public Intake GetIntakeWithStudents(int Id)
        {
            var intake = intakeRepo.GetIntakeWithStudents(Id);
            if (intake == null) throw new NullReferenceException($"There are no Intakes with this Id: {Id}");
            return intake;
        }
    
        public List<Intake> getAllIntakes()
        {
            var Intakes = intakeRepo.GetAll().ToList();
            if (Intakes != null) return Intakes;
            else 
                return new List<Intake>(); 
        }
    }
}
