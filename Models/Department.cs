namespace Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Instructor>? Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<Intake>? Intakes { get; set; } = new List<Intake>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
