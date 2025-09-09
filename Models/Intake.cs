namespace Models
{
    public class Intake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? StartDate { get; set; }=DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Student>? Students { get; set; } = new List<Student>();

    }
}
