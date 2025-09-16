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
    public class DepartmentRepository : SingleKeyRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context):base(context) 
        {
            this.context = context;
        }
        public Department? GettWithCourses(int id)
        {
            return context.Departments.Include(x => x.Courses).FirstOrDefault(x => x.Id == id);
        }

        public Department? GetWithInstuctors(int id)
        {
            return context.Departments.Include(x => x.Instructors).FirstOrDefault(x => x.Id == id);
        }

        public Department? GetWithIntakes(int id)
        {
            return context.Departments.Include(x => x.Intakes).FirstOrDefault(x => x.Id == id);
        }
    }


}


