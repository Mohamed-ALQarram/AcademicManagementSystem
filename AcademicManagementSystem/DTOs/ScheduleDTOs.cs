using Models.Enums;

namespace AcademicManagementSystem.DTOs
{
    public record CreateScheduleDTO(DateTime StartDate, DateTime EndDate, WeekDays DayOfWeek);
    public record UpdateScheduleDTO(int SectionId,  int RoomId,  DateTime StartDate, DateTime EndDate, WeekDays DayOfWeek);
    
}
