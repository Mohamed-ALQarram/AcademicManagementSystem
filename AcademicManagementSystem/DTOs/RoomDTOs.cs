using Models.Enums;

namespace AcademicManagementSystem.DTOs
{
     public record CreateRoomDTO(string Name, string? Location, int Capacity, RoomType RoomType);
     public record UpdateRoomDTO(int Id, string Name, string? Location, int Capacity, RoomType RoomType);
}
