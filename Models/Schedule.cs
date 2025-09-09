using Models.Enums;

namespace Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeekDays DayOfWeek { get; set; }
        public virtual Section Section { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
