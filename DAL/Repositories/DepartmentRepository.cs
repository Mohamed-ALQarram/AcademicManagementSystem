using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Department entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Departments.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.AsNoTracking();
        }

        public IEnumerable<Department> GetAllWithCourses()
        {
            return context.Departments.Include(x=>x.Courses).AsNoTracking();
        }

        public IEnumerable<Department> GetAllWithInstuctors()
        {
            return context.Departments.Include(x => x.Instructors).AsNoTracking();
        }

        public IEnumerable<Department> GetAllWithIntakes()
        {
            return context.Departments.Include(x => x.Intakes).AsNoTracking();
        }

        public Department GetById(int id)
        {
            var Dept = context.Departments.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Dept is null) throw new NullReferenceException("There is no Department With this Id");
            return Dept;
        }

        public void Update(Department entity)
        {
            var dept = context.Departments.Find(entity.Id);
            if (dept != null)
            {
                dept.Name = entity.Name;
                dept.Description = entity.Description;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Department With this Id");
        }
    }


}


