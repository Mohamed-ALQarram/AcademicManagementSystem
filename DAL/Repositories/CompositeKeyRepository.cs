using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompositeKeyRepository<T, Tkey> : Repository<T>, ICompositeKeyRepository<T, Tkey> where T : class
    {
        private readonly AppDbContext context;

        public CompositeKeyRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Delete(Tkey key)
        {
            var entityType = context.Model.FindEntityType(typeof(T))!;
            var keyProps = entityType.FindPrimaryKey()!.Properties;

            var entity = Activator.CreateInstance<T>()!;

            foreach (var kp in keyProps)
                typeof(T).GetProperty(kp.Name)!
                    .SetValue(entity, typeof(Tkey).GetProperty(kp.Name)!.GetValue(key));

            context.Entry(entity).State = EntityState.Deleted;
        }

        public T? GetById(Tkey key)
        {
            return context.Set<T>().Find(key);
        }

    }
}
