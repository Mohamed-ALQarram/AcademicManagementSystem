using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomService
    {
        private readonly ISingleKeyRepository<Room> roomRepo;
        private readonly ScheduleService scheduleService;

        public RoomService(ISingleKeyRepository<Room> roomRepo, ScheduleService scheduleService)
        {
            this.roomRepo = roomRepo;
            this.scheduleService = scheduleService;
        }
        public void AddRoom(Room Room)
        {
            roomRepo.Add(Room);
            roomRepo.SaveChanges();
        }
        public void UpdateRoom(Room Room)
        {
            roomRepo.Update(Room);
            roomRepo.SaveChanges();
        }
        public void DeleteRoom(int RoomId)
        {
            roomRepo.Delete(RoomId);
            roomRepo.SaveChanges();
        }
        public Room getRoomById(int RoomId)
        {
            var Room = roomRepo.GetById(RoomId);
            if (Room != null)
                return Room;
            else
                throw new NullReferenceException($"There are no Rooms with this Id: {RoomId}");
        }
        public List<Room> GetAllRooms()
        {
            var Rooms = roomRepo.GetAll().ToList();
            if (Rooms is null) return new List<Room>();
            return Rooms;
        }

        public List<Schedule> GetRoomSchedules(int RoomId)
        {
            return scheduleService.GetSchdulesByRoom(RoomId);
        }
    }
}
