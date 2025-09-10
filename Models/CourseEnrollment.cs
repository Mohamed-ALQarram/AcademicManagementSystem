namespace Models
{
    public class CourseEnrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? SectionId { get; set; }
        public double? Grade { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
