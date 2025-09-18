namespace AcademicManagementSystem.DTOs
{
    public record CreateSectionDTO(int CourseId, int InstructorId, int Capacity);
    public record UpdateSectionDTO(int SectionId, int CourseId, int InstructorId, int Capacity);
    
}
