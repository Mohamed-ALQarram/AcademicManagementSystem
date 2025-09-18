using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AcademicManagementSystem.DTOs
{
    public record AddInstructorDTO(

        [Display(Name ="First Name")]
        [Required]
        string FirstName,

        [Display(Name = "Last Name")]
        [Required]
        string LastName, 
        decimal Salary,

        [EmailAddress]
        [Required]
        string Email,

        [Phone]
        [Display(Name = "Phone")]
        string? PhoneNumber,

        [Display(Name = "Department Id")]
        [Required]
        int DepartmentId
        );
    public record UpdateInstructorDTO(
        [Required]
        [Display(Name ="Instructor Id")]
        int InstructorId,

        [Display(Name ="First Name")]
        [Required]
        string FirstName,

        [Display(Name = "Last Name")]
        [Required]
        string LastName, 
        decimal Salary,

        [EmailAddress]
        [Required]
        string Email,

        [Phone]
        [Display(Name = "Phone")]
        string? PhoneNumber,

        [Display(Name = "Department Id")]
        [Required]
        int DepartmentId
        );

    public record AddGradeDTO(int StudentId, int CourseId, double Grade);


}
