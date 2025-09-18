using Models.Enums;

namespace Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public AttendStatus AttendStatus { get; set; }
        public string? Reason { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;

    }
}
