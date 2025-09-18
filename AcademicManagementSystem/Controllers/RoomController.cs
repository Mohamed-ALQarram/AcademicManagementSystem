using AcademicManagementSystem.DTOs;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AcademicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public ActionResult<List<Room>> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Room> GetRoom(int id)
        {
            return roomService.GetRoomById(id);
        }

        [HttpGet("Schedules/{RoomId:int}")]

        public ActionResult<List<Schedule>> GetRoomSchedules(int RoomId)
        {
            return roomService.GetRoomSchedules(RoomId);
        }

        [HttpPost]
        public ActionResult CreateRoom(CreateRoomDTO Room)
        {
            roomService.AddRoom(
            new Room
            {
                Name = Room.Name,
                Location = Room.Location,
                Capacity = Room.Capacity,
                RoomType = Room.RoomType
            });
            return Created();
        }

        [HttpPut]
        public ActionResult EditRoom(UpdateRoomDTO Room)
        {
            roomService.UpdateRoom(
            new Room
            {
                Id = Room.Id,
                Name = Room.Name,
                Location = Room.Location,
                Capacity = Room.Capacity,
                RoomType = Room.RoomType
            });
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult DeleteRoom(int Id)
        {
            roomService.DeleteRoom(Id);
            return NoContent();
        }

    }
}
