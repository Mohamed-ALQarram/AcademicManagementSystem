namespace AcademicManagementSystem.DTOs
{
    public record CreateStudentDTO(string FirstName, string LastName, string? Email, string PhoneNumber, int IntakeId);
    public record UpdateStudentDTO(int StudentId, string FirstName, string LastName, string? Email, string PhoneNumber, int IntakeId);
}
