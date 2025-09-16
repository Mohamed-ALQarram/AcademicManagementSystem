using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void SaveChanges();

    }
}
