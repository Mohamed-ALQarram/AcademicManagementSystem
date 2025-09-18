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

        public DepartmentRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public IQueryable<Course> GetCourses(int id)
            => context.Departments
                          .Where(d => d.Id == id)
                          .SelectMany(d => d.Courses ?? new List<Course>());

        public IQueryable<Instructor> GetInstuctors(int id)
        => context.Departments
                .Where(x => x.Id == id)
                .SelectMany(x => x.Instructors?? new List<Instructor>());

        public IQueryable<Intake> GetIntakes(int id)
            => context.Departments
                .Where(x => x.Id == id)
                .SelectMany(x => x.Intakes ?? new List<Intake>());

    }
}



