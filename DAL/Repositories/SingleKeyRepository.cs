using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SingleKeyRepository<T>: Repository<T>, ISingleKeyRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public SingleKeyRepository(AppDbContext context):base(context) 
        {
            this.context = context;
        }
        public T GetById(int id)
        {
            var Result = context.Set<T>().Find(id);
            if (Result != null)
            {
                return Result;
            }
            else
                throw new NullReferenceException("Invalid Id");
        }
        public void Delete(int id)
        {
            //var result =context.Set<T>().Find(id);
            //if (result != null)
            //    context.Set<T>().Remove(result);

            //Optimized way for delete Generics
            var key = context.Model.FindEntityType(typeof(T))
                                   !.FindPrimaryKey()
                                   !.Properties.First();
            var entity = Activator.CreateInstance<T>();
            typeof(T).GetProperty(key!.Name)?.SetValue(entity, id);
            context.Entry(entity).State = EntityState.Deleted;
        }


    }
}
