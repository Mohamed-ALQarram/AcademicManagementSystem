namespace Models
{
    public class Section
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int Capacity { get; set; }
        public virtual Course Course { get; set; } = null!;
        public virtual Instructor Instructor { get; set; } = null!;
        public virtual ICollection<Attendence>? Attendences { get; set; } = new List<Attendence>();
        public virtual ICollection<Schedule>? Schedules { get; set; } = new List<Schedule>();
        public virtual ICollection<CourseEnrollment>? CourseEnrollments { get; set; } = new List<CourseEnrollment>();
    }
}
