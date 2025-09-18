namespace AcademicManagementSystem.DTOs
{
    public record CreateDepartmentDTO(string Name, string? Description);
    public record UpdateDepartmentDTO(int Id, string Name, string? Description);
}
