namespace Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public int Hours { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<CourseEnrollment>? CourseEnrollments { get; set; } = new List<CourseEnrollment>();
        public virtual ICollection<Section>? Sections { get; set; } = new List<Section>();
    }
}
