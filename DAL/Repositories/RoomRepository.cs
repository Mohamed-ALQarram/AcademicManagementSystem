using Core;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class RoomRepository : IRepository<Room>, ISingleKeyRepository<Room>
    {
        private readonly AppDbContext context;

        public RoomRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Room entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Rooms.Where(x => x.Id == id).ExecuteDelete();
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.AsNoTracking();
        }

        public Room GetById(int id)
        {
            var Room = context.Rooms.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Room == null) throw new NullReferenceException("There is no Room With this Id");
            return Room;
        }

        public void Update(Room entity)
        {
            var Room = context.Rooms.Find(entity.Id);
            if (Room != null)
            {
                Room.Name = entity.Name;
                Room.Capacity = entity.Capacity;
                Room.Location = entity.Location;
                Room.RoomType = entity.RoomType;
                context.SaveChanges();
            }
            else
                throw new NullReferenceException("There is no Section With this Id");
        }
    }


}


