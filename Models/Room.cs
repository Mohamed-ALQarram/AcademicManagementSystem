using Models.Enums;

namespace Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
