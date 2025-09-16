using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IInstructorRepository:IRepository<Instructor>, ISingleKeyRepository<Instructor>
    {
        public IQueryable GetInstructorLookup();
    }
}
