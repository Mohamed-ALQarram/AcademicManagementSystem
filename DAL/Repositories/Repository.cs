using Core;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }


        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

}


