namespace Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }=null!;
        public int IntakeId { get; set; }
        public virtual Intake Intake { get; set; } = new Intake();
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
        public virtual ICollection<Attendance> Attendences { get; set; } = new List<Attendance>();
    }
}
