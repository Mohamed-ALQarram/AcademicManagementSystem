using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AcademicManagementSystem.DTOs
{
    public record CreateAttendanceDTO
    (
        [Required]
        [Display(Name = "Student Id")]
        int StudentId,

        [Required]
        int SectionId,

        [Required]
        AttendStatus Status,

         string? Reason
    );
    public record UpdateAttendanceDTO
    (
        [Required]
        int Id,

        [Required]
        [Display(Name = "Student Id")]
        int StudentId,

        [Required]
        int SectionId,

        [Required]
        AttendStatus Status,

         string? Reason
    );
}
