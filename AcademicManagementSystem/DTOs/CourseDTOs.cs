namespace AcademicManagementSystem.DTOs
{
    public record CreateCourseDTO(string CourseName, string? Code, int Hours, int DepartmentId);
    public record UpdateCourseDTO(int CourseId, string CourseName, string? Code, int Hours, int DepartmentId);

}
