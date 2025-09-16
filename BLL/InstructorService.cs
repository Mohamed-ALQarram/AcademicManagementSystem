using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InstructorService
    {
        private readonly IInstructorRepository instructorRepo;

        public InstructorService(IInstructorRepository instructorRepo)
        {
            this.instructorRepo = instructorRepo;
        }
        public void AddInstructor(Instructor instructor) 
        {
            instructorRepo.Add(instructor);
            instructorRepo.SaveChanges();

        }
        public void DeleteInstructor(int instructorId) 
        { 
            instructorRepo.Delete(instructorId);
            instructorRepo.SaveChanges();
        }
        public void UpdateInstructor(Instructor instructor) 
        {
            instructorRepo.Update(instructor);
            instructorRepo.SaveChanges();
        }

        public Instructor GetInstructorById(int instructorId)
        {
            return instructorRepo.GetById(instructorId);
        }
        public IQueryable GetInstructorLookup()
        {
            return instructorRepo.GetInstructorLookup();
        }
        public List<Instructor> GetInstructors() 
        {
        return instructorRepo.GetAll().ToList();
        }

    }
}
