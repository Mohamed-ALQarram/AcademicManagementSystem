namespace Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }= DateTime.UtcNow;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Section>? Sections { get; set; } = new List<Section>();  
    }
}
