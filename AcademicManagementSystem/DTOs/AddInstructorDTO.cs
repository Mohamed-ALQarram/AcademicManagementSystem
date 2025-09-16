using System.ComponentModel.DataAnnotations;

namespace AcademicManagementSystem.DTOs
{
    public class AddInstructorDTO
    {
        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [Phone]
        [Display(Name = "Phone")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Department Id")]
        [Required]
        public int DepartmentId { get; set; }

    }
}
