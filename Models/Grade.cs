namespace Models
{
    public class Grade
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double StudentGrade { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;

    }
}
